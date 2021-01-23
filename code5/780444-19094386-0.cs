    public interface IInterface
    {
        ...
    }
    
    public class Class1 : IInterface
    {
        ...
    }
    
    public interface IBase<out T> where T: IInterface
    {
        // Need to add out keyword for covariance.
    }
    
    public class Base<T> : IBase<T> where T : IInterface
    {
        ...
    }
    public class Class2<T> : Base<T> where T : IInterface
    {
        ...
    }
    
    .
    .
    .
    
    public SomeMethod()
    {
        List<IBase<IInterface>> list = new List<IBase<IInterface>>();
        Class2<Class1> item = new Class2<Class1>();
        list.Add(item); // No compile time error here.
    }
