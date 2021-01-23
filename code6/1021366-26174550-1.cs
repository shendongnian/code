    public class MyViewModel : INofityPropertyChanged
    {
        private string _myProperty;
        public string MyProperty
        { 
            get { return _myProperty; }
            set
            {
                _myProperty = value;
                 NotifyPropertyChanged("MyProperty");
            }
        }
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
