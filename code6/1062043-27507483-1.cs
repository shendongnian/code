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
            get { return FirstName; }
            set
            {
                if (value == FirstName)
                    return;
                .FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        private string lastName;
        public string LastName
        {
            get { return LastName; }
            set
            {
                if (value == LastName)
                    return;
               LastName = value;
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
