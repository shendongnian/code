    public interface IMyClassFactory
    {
       IMyClass Create(bool val);
    }
    
    public interface IMyClass
    {
       //whatever methods, etc, it's supposed to have.
    }
    
    public class MyClass:IMyClass
    {
       public MyClass(bool val)
        {
           //do something with val here in the ctor
        }
    }
    
