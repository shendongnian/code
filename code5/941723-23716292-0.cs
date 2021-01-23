        private int _idCounter;
        public int idCounter
        {
            get { return _idCounter; }
            set
            {
                if (_idCounter != value)
                {
                    _idCounter = value;
                    OnPropertyChanged("idCounter");
                }
            }
        }
