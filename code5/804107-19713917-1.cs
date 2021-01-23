    public class Foo
    {
        private string _variableValue;
        public string VariableValue
        {
            get
            {
                return Double.Parse(_variableValue).ToString("N" + Precision);
            }
            set
            {
                if (value == _variableValue) return;
                _variableValue = value;
            }
        }
        public int Precision { get; set; }
    }
