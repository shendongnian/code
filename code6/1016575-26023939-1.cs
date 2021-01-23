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
                    //Formatting as a float then padding left with 0's should give the format you want
                    base.Text = temp.ToString("F2").PadLeft(5,'0');
                else
                    //Handle invalid input here. 
                    base.Text = "--.--";
            }
        }
    }
