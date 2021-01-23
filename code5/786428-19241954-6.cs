    internal class Poco { ... }     // this 'internal' is a problem 
    internal interface ITest1       // this isn't
    { 
      Poco Obj  {  }                // Poco is an internal type
    }
    public class Foo : ITest1
    {
        // Not working
        Poco Obj  { ... }          // property _and_ type need to be public
    }
