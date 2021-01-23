        private double _fontSize = 10;
        public double FontSize
        {
            get { return _fontSize; }
            set
            {
                if (value != _fontSize)
                {
                    _fontSize = value;
                    NotifyPropertyChanged();
                }
            }
        }
