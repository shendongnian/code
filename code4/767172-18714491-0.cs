    public class MyModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    
        private string _firstName;
    
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName == value) return;
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
    
        private string _secondName;
    
        public string SecondName
        {
            get { return _secondName; }
            set
            {
                if (_secondName == value) return;
                _secondName = value;
                OnPropertyChanged("SecondName");
            }
        }
    }
