    public class Class1ToSave : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _property1;
        public int Property1
        {
            get
            {
                return _property1;
            }
            set
            {
                if(_property1 != value)
                {
                    _property1 = value;
                    OnPropertyChanged("Property1");
                }
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
                if(PropertyChanged != null)
                {
                        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
        }
    }
