     public class Student : IDataErrorInfo, INotifyPropertyChanged
    {
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        private Student()
        {
        }
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value == FirstName)
                    return;
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value == lastName)
                    return;
               lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        //...
    }
