    public class MyViewModel : INotifyPropertyChanged
    {
        private string _firstName;
       
 
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
 
       
        }
    }
