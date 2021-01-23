    public class Person
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Sex { get; set; }
        public string Address { get;set;}
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", Name, Age, Sex, Address);
        }
    }
    public class PersonViewModel
    {
        public PersonViewModel()
        {
            PersonList = (from p in DataContext.Person
                          select new Person
                          {
                              Name = p.Name,
                              Age = p.Age,
                              Sex = p.Sex,
                              Address = p.Address
                          }).ToList();
        }
        public List<Person> PersonList { get; set; }
        public Person SelectedPerson { get; set; }
    }
