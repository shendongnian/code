    // Specify list of strings to match against Id
    var listOfStrings = new List<string> { "1", "2", "3", "4" };
    // Your "A" class
    public class A
    {
        public string Id;
        public string Name;
    }
    // A new list of A objects with some Ids that will match
    var listOfA = new List<A> 
    {
        new A { Id = "2", Name = "A-2" },
        new A { Id = "4", Name = "A-4" },
    };
    // Search for A objects in the list where the Id is part of your string list
    var matches = listOfA.Where(x => listOfstrings.Contains(x.Id)).ToList();
