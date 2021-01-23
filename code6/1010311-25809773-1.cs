    public class Person
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
    }
    var list = new List<Person>
    {
        new Person {FirstName = "Viviane", LastName = "York"},
        new Person {FirstName = "Mike", LastName = "Buffalo"},
        new Person {FirstName = "Theo", LastName = "York"},
        new Person {FirstName = "John", LastName = "Case"}
    };
    var sorted = list.OrderBy( p => p.LastName).ThenBy( p => p.FirstName).ToList();
