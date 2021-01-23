    public class Foo
    {
        private double_variableValue;
        public string VariableValue
        {
            get
            {
                return _variableValue.ToString("N" + Precision);
            }
            set
            {
                if (value == _variableValue.ToString()) return;
                Double.TryParse(value, _variableValue); // in case of non-numerics
            }
        }
        public int Precision { get; set; }
    }
