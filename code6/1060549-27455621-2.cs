    public class Person
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public DateTime BirthDate { get; set; }
    }
    var people = new List<Person>
    {
        new Person { Name = "Bob", Height = 72, BirthDate = new DateTime(1984,1,1) },
        new Person { Name = "Mary", Height = 64, BirthDate = new DateTime(1980,2,2) }
    };
    var oneAnonList = people.Select(x => new { x.Name, x.BirthDate });
    var twoAnonList = people.Select(x => new { x.Height, x.Name });
    var myTuple = Tuple.Create(oneAnonList, twoAnonList);
