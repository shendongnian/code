     private float _floatOne;
        public float FloatOne
        {
            get
            {
                return _floatOne;
            }
            set
            {
                if (_floatOne == value)
                {
                    return;
                }
                _floatOne = value;
                OnPropertyChanged();
                Result = _floatOne + _floatTwo;
            }
        }
        private float _floatTwo;
        public float FloatTwo
        {
            get
            {
                return _floatTwo;
            }
            set
            {
                if (_floatTwo == value)
                {
                    return;
                }
                _floatTwo = value;
                OnPropertyChanged();
                Result = _floatOne + _floatTwo;
            }
        }
        private float _result;
        public float Result
        {
            get
            {
                return _result;
            }
            set
            {
                if (_result == value)
                {
                    return;
                }
                _result = value;
                OnPropertyChanged();
            }
        }
