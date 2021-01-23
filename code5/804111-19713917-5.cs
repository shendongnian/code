    public class Foo
    {
        private string _variableValue;
        public string VariableValue
        {
            get
            {
                double doubleValue;
                Double.TryParse(_variableValue, out doubleValue); // in the case of non-numerics
                return doubleValue.ToString("N" + Precision);
            }
            set
            {
                if (value == _variableValue) return;
                _variableValue = value;
            }
        }
        public int Precision { get; set; }
    }
