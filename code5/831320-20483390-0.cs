        class Program
        {
        private int _variableValue;
        private bool _isIncreasing;
        public int Variable
        {
            get
            {
                return _variableValue;
            }
            set
            {
                _isIncreasing = _variableValue <= value;
                _variableValue = value;
            }
        }
        void Main(string[] args)
        {
            Variable = 0;
            Variable = 1;
            if (_isIncreasing)
            {
                //Do Magic stuff
            }
        }
    }
