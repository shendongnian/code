    public class ViewModel {
        public ViewModel() {
            Persons = new ObservableCollection<Person> { 
                new Person(){ FirstName = "Peter", LastName ="Parker", Age=33 },
                new Person(){ FirstName = "Mary", LastName ="Jane" , Age=31 }
            };
        }
        public ObservableCollection<Person> Persons { get; private set; }
        public Person SelectedPerson { get; set; }
    }
