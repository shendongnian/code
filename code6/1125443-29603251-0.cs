    class SomeClass : INotifyPropertyChanged
    {
        private string someProperty;
        public string SomeProperty 
        {
            get { return someProperty; }
            set { someProperty = value; OnPropertyChanged(); }
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName);
        }
        public event EventHandler<PropertyChangedEventArgs> PropertyChanged = delegate {};
    }
