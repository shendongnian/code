     public class MainViewModel
    {
        public MainViewModel(IPeopleService service)
        {
            var people = service.GetPeople();
            People = new ObservableCollection<Person>(people.Select(p => new Person(p)));
        }
        public ObservableCollection<Person> People { get; set; }
        private Person _person;
        public Person SelectedPerson
        {
            get
            {
                return _person;
            }
            set
            {
                if(value != null)
                {
                    _person = value;
                    OnPropertyChanged("SelectedPerson");
                    //Send selected person on each change
                    Messenger.Default.Send<Person>(_person);
                }
            }
        }
    }
