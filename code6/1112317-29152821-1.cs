        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(String info)
        {
            if (PropertyChanged != null)            
                PropertyChanged(this, new PropertyChangedEventArgs(info));            
        }
