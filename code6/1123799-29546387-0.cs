    public interface IEntity
    {
        string Name { get; set;}
        string LastName { get; set;}
    }
    public class Entity1 : IEntity
    {
        public string Name { get; set;}
        public string LastName { get; set;}
    }
    public class Entity2 : IEntity
    {
        public string Name { get; set;}
        public string LastName { get; set;}
    }
    //...and later in your main code...
    foreach(IEntity person in results)
    {
        Console.WriteLine("First Name: {0}, Last Name: {1}", person.Name, person.LastName);
    }
