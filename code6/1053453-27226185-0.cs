    class Car
    {
        private int _someValue;
        public int SomeValue
        {
            get { return _someValue; }
            set
            {
                if(value > 100)
                    throw new OutOfRangeException(...);
                _someValue = value;
            }
        }
    }
