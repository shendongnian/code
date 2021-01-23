    public interface IFoo
    {
        void CallSomeMethod();
    }
    public class MyGenericClass<T> : IFoo
    {
        ...
    }
    // Names changed to be more conventional
    public void DoSomething(Type type)
    {
        var genericType = typeof(MyGenericClass<>).MakeGenericType(type);
        var instance = (IFoo) Activator.CreateInstance(genericType);
        instance.CallSomeMethod();
    }
