    class SomeClass : INotifyPropertyChanged
    {
        private string someProperty;
        public string SomeProperty 
        {
            get { return someProperty; }
            set { someProperty = value; OnPropertyChanged("SomeProperty"); }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate {};
    }
