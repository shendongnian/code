    public class MainViewModel : ViewModelBase
    {
        private PersonModel model;
        private Person person;
        public Person Person
        {
            get { return person; }
            set { SetField(ref person, value); } // updates the field and raises OnPropertyChanged
        }
        public ICommand Update { get { return new RelayCommand(UpdatePerson); } }
        private void UpdatePerson()
        {
            if (someCondition)
            {
                // restore the old values
                Person = new Person(model.Person.FirstName, model.Person.LastName, model.Person.Age);
            }
            // update the model
            model.Person = new Person(Person.FirstName, Person.LastName, Person.Age);
        }
    }
