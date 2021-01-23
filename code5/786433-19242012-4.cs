    public interface IPoco { 
       string Title {get; } //restring writing, for example
    }
    internal class Poco : IPoco
    {
       public string Title {get; set; } //read/write access within the assembly
    }
    public class Foo 
    {
       public IPoco MyPoco {get; set;}
    }
