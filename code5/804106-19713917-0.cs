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
                _variableValue = Double.Parse(value);
            }
        }
        public int Precision { get; set; }
    }
