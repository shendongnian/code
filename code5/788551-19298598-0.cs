    public abstract class MyBaseClass
    {
        ...
    }
    
    public abstract class MyClass<T> : MyBaseClass
        where T: MyClass<T>
    {
        ...
    }
