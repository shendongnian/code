    // Specify list of strings to match against Id
    var listOfStrings = new List<string> { "1", "2", "3", "4" };
    // Your "A" class
    public class A
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    // A new list of A objects with some Ids that will match
    var listOfA = new List<A> 
    {
        new A { Id = "2", Name = "A-2" },
        new A { Id = "4", Name = "A-4" },
    };
