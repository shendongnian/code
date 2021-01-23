    public class NumericUpDownEx : NumericUpDown
    {
        public NumericUpDownEx()
        {
        }
        protected override void UpdateEditText()
        {
            if (Value < 0)
            {
                Text = "infinite";
            }
            else
            {
                base.UpdateEditText();
            }
        }
    }
