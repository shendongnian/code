    public class Age
    {
        public Age(int age) : this(0, 75, age) { }
        public Age(int minAge, int maxAge) : this(minAge, maxAge, minAge) { }
        public Age(int minAge, int maxAge, int age)
        {
            this._Minimum = minAge;
            this._Maximum = maxAge;
            this.Value = age;
        }
        private int _Value = 0;
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
               CheckRange(value, true);
            }
        }
        private int _Maximum = 0;
        public int MaximumAge
        {
            get
            {
                return _Maximum;
            }
            set
            {
                _Maximum = value;
                CheckRange(value, false);
            }
        }
        private int _Minimum = 0;
        public int MinimumAge
        {
            get
            {
                return _Minimum;
            }
            set
            {
                _Minimum = value;
                CheckRange(value, false);
            }
        }
        private void CheckRange(int value, bool setValueAnyway)
        {
            if (value < _Minimum)
                _Value = _Minimum;
            else if (value > _Maximum)
                _Value = _Maximum;
            else if (setValueAnyway)
                _Value = value;
        }
    }
