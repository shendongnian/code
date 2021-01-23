     public class PersonViewModel
    {
        private Person _person;
        public Person SelectedPerson
        {
            get
            {
                return _person;
            }
            set
            {
                if (value != null)
                {
                    _person = value;
                    OnPropertyChanged("SelectedPerson");                    
                }
            }
        }
        public PersonViewModel()
        {
            Messenger.Default.Register<Person>(this, (p) =>
                {
                    SelectedPerson = p;
                });
        }
    }
