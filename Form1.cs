using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace parkingmetersimiulator
{
    public enum ParkometerState
    {
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Paid,
        NA,
    }

    public partial class Form1 : Form
    {
        private ParkometerState _parkometerState;
        public ParkometerState ParkometerState
        {
            get
            {
                return this._parkometerState;
            }
            set
            {
                this._parkometerState = value;
                if (value == ParkometerState.Paid)
                    MessageBox.Show("Zaplacono");
                if (value == ParkometerState.NA)
                    MessageBox.Show("Niedozwolony stan, zwrot pieniedzy");

                this.listView1.Items?.Add(value.ToString());
            }
        }

        Dictionary<ParkometerState, Func<int, ParkometerState>> StateFunctionDictionary =
            new Dictionary<ParkometerState, Func<int, ParkometerState>>();

        public Form1()
        {
            InitializeComponent();
            this.StateFunctionDictionary.Add(ParkometerState.Zero, (p) =>
            {
                switch (p)
                {
                    case 1:
                        return ParkometerState.One;
                    case 2:
                        return ParkometerState.Two;
                    case 5:
                        return ParkometerState.Five;
                    default:
                        return ParkometerState.NA;
                }
            });
            this.StateFunctionDictionary.Add(ParkometerState.One, (p) =>
            {
                switch (p)
                {
                    case 1:
                        return ParkometerState.Two;
                    case 2:
                        return ParkometerState.Three;
                    case 5:
                        return ParkometerState.Six;
                    default:
                        return ParkometerState.NA;
                }
            });
            this.StateFunctionDictionary.Add(ParkometerState.Two, (p) =>
            {
                switch (p)
                {
                    case 1:
                        return ParkometerState.Three;
                    case 2:
                        return ParkometerState.Four;
                    case 5:
                        return ParkometerState.Paid;
                    default:
                        return ParkometerState.NA;
                }
            });
            this.StateFunctionDictionary.Add(ParkometerState.Three, (p) =>
            {
                switch (p)
                {
                    case 1:
                        return ParkometerState.Four;
                    case 2:
                        return ParkometerState.Five;
                    case 5:
                        return ParkometerState.NA;
                    default:
                        return ParkometerState.NA;
                }
            });
            this.StateFunctionDictionary.Add(ParkometerState.Four, (p) =>
            {
                switch (p)
                {
                    case 1:
                        return ParkometerState.Five;
                    case 2:
                        return ParkometerState.Six;
                    case 5:
                        return ParkometerState.NA;
                    default:
                        return ParkometerState.NA;
                }
            });
            this.StateFunctionDictionary.Add(ParkometerState.Five, (p) =>
            {
                switch (p)
                {
                    case 1:
                        return ParkometerState.Six;
                    case 2:
                        return ParkometerState.Paid;
                    case 5:
                        return ParkometerState.NA;
                    default:
                        return ParkometerState.NA;
                }
            });
            this.StateFunctionDictionary.Add(ParkometerState.Six, (p) =>
            {
                switch (p)
                {
                    case 1:
                        return ParkometerState.Paid;
                    case 2:
                        return ParkometerState.NA;
                    case 5:
                        return ParkometerState.NA;
                    default:
                        return ParkometerState.NA;
                }
            });
            this.StateFunctionDictionary.Add(ParkometerState.Paid, (p) =>
            {
                switch (p)
                {
                    case 1:
                        return ParkometerState.One;
                    case 2:
                        return ParkometerState.Two;
                    case 5:
                        return ParkometerState.Five;
                    default:
                        return ParkometerState.NA;
                }
            });
            this.StateFunctionDictionary.Add(ParkometerState.NA, (p) =>
            {
                switch (p)
                {
                    case 1:
                        return ParkometerState.One;
                    case 2:
                        return ParkometerState.Two;
                    case 5:
                        return ParkometerState.Five;
                    default:
                        return ParkometerState.NA;
                }
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ParkometerState = this.StateFunctionDictionary[this.ParkometerState](1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ParkometerState = this.StateFunctionDictionary[this.ParkometerState](2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.ParkometerState = this.StateFunctionDictionary[this.ParkometerState](5);
        }
    }
}
