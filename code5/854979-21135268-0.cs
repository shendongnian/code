    public class MyViewModelClass : INotifyPropertyChanged 
    {
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged(); }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged(); }
        }
        private string age;
        public string Age
        {
            get { return age; }
            set { age= value; OnPropertyChanged(); }
        }
        //Also the INotifyProperty members ...
    }
    
