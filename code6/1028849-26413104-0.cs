    class MyData : INotifyPropertyChanged
    {
        private string info;
        public string Info
        {
            get { return info; }
            set
            {
                if (info != value)
                {
                    info = value;
                    RaisePropertyChanged("Info");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
