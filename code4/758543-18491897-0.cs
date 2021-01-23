    public class MyViewModel: NotificationObject
    {
        private string _lastName;
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                RaisePropertyChanged(() => Greeting);
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                RaisePropertyChanged(() => Greeting);
            }
        }
        public string Greeting
        {
            get { return string.Format("Hello {0} {1}!", _firstName, _lastName); }
        }
    }
