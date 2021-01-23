    public class BLMethods
    {
        readonly Action<string> _displayValue;
    
        public BLMethods(Action<string> displayValue)
        {
            _displayValue = displayValue;
        }
    
        public void DisplayValue()
        {
           _displayValue("This is from Bl Class");
        }
    }
