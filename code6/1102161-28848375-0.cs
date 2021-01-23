    public class MyViewModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
 
        public event PropertyChangedEventHandler PropertyChanged;
 
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName == value)
                    return;
 
                _firstName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
            }
        }
 
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName == value)
                    return;
 
                _lastName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
            }
        }
    }
