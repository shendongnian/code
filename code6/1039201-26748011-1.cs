    void Main()
    {
        var firstListOfPeople = new[]
        {
            new Person { Name = "Rufus" },
            new Person { Name = "Bob" },
            new Person { Name = "steve" },
        };
        
        var secondListOfPeople = new[]
        {
            new Person { Name = "john" },
            new Person { Name = "Bob" },
            new Person { Name = "rufus" },
        };
        
        var people = firstListOfPeople.Intersect(secondListOfPeople, new PersonNameComparer());
        
        people.Dump(); // displays the result if you are using LINQPad
    }
    
    public class Person
    {
        public string Name { get; set; }
    }
    
    public class PersonNameComparer: EqualityComparer<Person>
    {
    
        public override bool Equals(Person p1, Person p2)
        {
            return p1.Name.Equals(p2.Name, StringComparison.OrdinalIgnoreCase);
        }
    
        public override int GetHashCode(Person p)
        {
            return p.Name.ToLower().GetHashCode();
        }
    }
