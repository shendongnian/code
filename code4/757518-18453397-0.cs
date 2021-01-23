    private Namess _selectedCustomer;
    public Namess SelectedCustomer
    {
        get { return _selectedCustomer; }
        set
        {
            if (_selectedCustomer != value)
            {
                _selectedCustomer = value;
                OnPropertyChanged("SelectedCustomer");
            }
         }
        public List<Namess> ListPerson { get; set; }
        void CreateList()
        {
            ListPerson = new List<Namess>();
            for (int i = 0; i < 10; i++)
            {
                ListPerson.Add(new Namess(i));
            }
        }
        public class Namess : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                    handler(this, new PropertyChangedEventArgs(propertyName));
            }
            public Namess(int i)
            {
                FirstName = "FirstName" + i;
                LastName = "LastName" + i;
                Age = i * 10;
            }
            public string FirstName { get; set; }
            private string _lastName;
            public string LastName 
            { 
                get
                {
                    return _lastName;
                }
                set
                {
                    if(value==_lastName)
                        return;
                    _lastName=value;
                    OnPropertyChanged("LastName");
                }
            }
            public int Age { get; set; }
        }
    }
