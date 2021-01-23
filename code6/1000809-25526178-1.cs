        public Stop SelectedStop
        {
            get
            {
                return _selectedStop;
            }
            set
            {
                if (Equals(value, _selectedStop)) return;
                _selectedStop = value;
            }
        }
