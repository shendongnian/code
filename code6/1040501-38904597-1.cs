    // NOTE: Use properties instead of public variables
    public class Person
    {
        public string Name { get; set; }
        public string State { get; set; }
    }
	// NOTE: Use properties instead of public variables
	public class personGroup
	{
		public string State { get; set; }
	}
    void Main()
    {   
        var people = new List<Person>();
        people.Add(new Person{Name = "Bob", State = "Tx"});
        people.Add(new Person{Name = "Bill", State = "Tx"});
        var morePeople = people.GroupBy(p => new personGroup{State = p.State}, new PropertyEqualityComparer<Person>());
        morePeople.Count();
    }
    
