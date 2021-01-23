    public class SomeContext 
    {
        public ObservableCollection<Person> People { get; set; }
        public SomeContext()
        {
            People = new ObservableCollection<Person>();
            People.Add(new Person { Name = "Samuel" });
        }
        public void AddPerson()
        {
            People.Add(new Person { Name = "Peter" });
        }
    }
    public class Person
    {
        public string Name { get; set; }
    } 
