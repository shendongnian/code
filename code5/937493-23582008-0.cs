    public interface IFoo
    {
        IList<string> Foos {get; set;}
    }
    
    public class Foo : IFoo
    {
        public List<string> Foos {get; set;}
    }
