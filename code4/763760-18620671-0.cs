    //You can use this class instead of the standard NumericUpDown
    public class CustomNumericUpDown : NumericUpDown
    {
        //Override this to format the displayed text
        protected override void UpdateEditText()
        {
            Text = Value.ToString("0." + new string('#', DecimalPlaces));
        }
    }
