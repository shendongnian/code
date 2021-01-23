    public class MyObject : INotifyPropertyChanged
    {
        private string _myProperty;
        public string MyProperty
        {
            get { return _myProperty; }
            set
            {
                _myProperty = value;
                NotifyPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
