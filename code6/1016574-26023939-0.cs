    public class NumDoubTextbox : TextBox
    {
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                double temp = 0;
                if (double.TryParse(value, out temp))
                    base.Text = string.Format("{0:00.00}",value);
                else
                    //Handle invalid input here. 
                    base.Text = "--.--";
            }
        }
    }
