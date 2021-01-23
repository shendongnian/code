        public bool IsEnable 
        {
            get { return isEnable; }
            set
            {
                isEnable = value; 
                NotifyPropertyChanged();
            } 
        }
        public async void GetText(object o)
        {
            await Task.Factory.StartNew(() =>
            {
                IsEnable = false;
            });
            IsEnable = true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
