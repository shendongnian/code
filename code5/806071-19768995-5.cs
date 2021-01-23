    public class Employee
    {
        public Employee()
        {
            Dogs = new ObservableCollection<Dog>
            {
                new Dog { Gender = 'M'},
                new Dog { Gender = 'F'},
            };
            Cats = new ObservableCollection<Cat>
            {
                new Cat { Name = "Mitzy" , Kind = "Street Cat"},
                new Cat { Name = "Mitzy" , Kind = "House Cat"}
            };
        }
        public string EmployeeName { get; set; }
        public ObservableCollection<Dog> Dogs { get; set; }
        public ObservableCollection<Cat> Cats { get; set; }
    }
    public class Dog
    {
        public char Gender { get; set; }
        public override string ToString()
        {
            return "Dog is a '" + Gender + "'";
        }
    }
    public class Cat
    {
        public string Name { get; set; }
        public string Kind { get; set; }
        public override string ToString()
        {
            return "Cat name is " + Name + " and it is a " + Kind;
        }
    }
