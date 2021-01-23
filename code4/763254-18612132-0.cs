    public class MyForm : Form
    {
        public string HeaderText
        {
            get {return this.Text;}
            set {this.Text = value;}
        }
        private MyLayoutEnum _LayoutStyle;
        public MyLayoutEnum LayoutStyle
        {
            get
            {
                return this._LayoutStyle;
            }
            set
            {
                this._LayoutStyle = value;
                switch (value)
                {
                    case MyLayoutEnum.Basic:
                        {
                            //do work
                            break;
                        }
                    case MyLayoutEnum.Advanced:
                        {
                            //do work
                            break;
                        }
                    default:
                        {
                            //unsupported case - for example
                            break;
                        }
                }
            }
        }
    }
    public enum MyLayoutEnum : int
    {
        None = 0,
        Basic = 1,
        Advanced = 2
    }
