    public class DisplayIfAttribute : Attribute
    {
        private string _propertyName;
        private string _trueValue;
        private string _falseValue;
        public string PropertyName
        {
            get { return _propertyName; }
        }
        public string TrueValue
        {
            get { return _trueValue; }
        }
        public string FalseValue
        {
            get { return _falseValue; }
        }
        public DisplayIfAttribute(string propertyName, string trueValue, string falseValue)
        {
            _propertyName = propertyName;
            _trueValue = trueValue;
            _falseValue = falseValue;
        }
    }
