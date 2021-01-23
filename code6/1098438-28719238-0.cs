    public interface IReadablePerson
    {
        string Name { get; }
    }
    public interface IWritablePerson
    {
        string Name { set; }
    }
    public class Person : IReadablePerson, IWritablePerson
    {
        public string Name { get; set; }
    }
