    public class ShellViewModel : Screen, IShell
    {
        private ObservableCollection<Person> people = new ObservableCollection<Person>();
        public ObservableCollection<Person> People
        {
            get
            {
                return this.people;
            }
            set
            {
                this.people = value;
                this.NotifyOfPropertyChange(() => this.People);
            }
        }
        private Person selectedPerson;
        public Person SelectedPerson
        {
            get
            {
                return this.selectedPerson;
            }
            set
            {
                this.selectedPerson = value;
                this.NotifyOfPropertyChange(() => this.SelectedPerson);
            }
        }
        public ShellViewModel()
        {
            var russell = new Person { Name = "Russell" };
            this.People.Add(new Person { Name = "Benjamin" });
            this.People.Add(new Person { Name = "Steve" });
            this.People.Add(russell);
            this.SelectedPerson = russell;
        }
