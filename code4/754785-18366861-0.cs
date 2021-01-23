    public interface IBar
    { 
        string Name { get; set; }
    }
    public class Foo<T> : IBar
    {
        public string Name { get; set; }
    }
