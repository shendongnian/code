    public interface IFooBar
    {
        // methods used for modifications
    }
    
    public class FooBar : IFooBar 
    {
        // implement modification methods
    }
    
    public class FooBar<T> : IFooBar where T : SomeClass
    {
        // implement modification methods
    }
    
    public class Foo
    {
       protected IFooBar SomeVar;
    
       public void DoSomething()
       {
           // Manipulate SomeVar via IFooBar interface here 
       }
    }
    
    public class Foo<T>: Foo where T: SomeObject
    {
 
    }
