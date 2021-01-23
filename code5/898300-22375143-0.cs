        public bool IsEnable 
        {
            get { return isEnable; }
            set
            {
                isEnable = value; 
                NotifyPropertyChanged();
            } }
