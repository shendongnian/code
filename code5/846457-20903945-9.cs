    public class MyViewModel
    {
        public MyViewModel()
        {
            this.People = new ObservableCollection<Person>()
            {
                new Person() { FirstName = "A", Surname = "B", MiddleName = "C", Age = 1},
                new Person() { FirstName = "D", Surname = "E", MiddleName = "F", Age = 2},
                new Person() { FirstName = "G", Surname = "H", MiddleName = "I", Age = 3},
                new Person() { FirstName = "J", Surname = "K", MiddleName = "L", Age = 4},
                new Person() { FirstName = "M", Surname = "N", MiddleName = "O", Age = 5}
            };
            this.Items = new ObservableCollection<GridItem>()
            {
                new GridItem() { Person = this.People[0]},
                new GridItem() { Person = this.People[1]},
                new GridItem() { Person = this.People[2]},
                new GridItem() { Person = this.People[3]}
            };
        }
        public ObservableCollection<Person> People { get; set; }
        public ObservableCollection<GridItem> Items { get; set; }
    }
