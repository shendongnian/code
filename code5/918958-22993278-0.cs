    interface IMyInterface
    {
        object MyProperty { get; }
    }
    public class MyClass2<T> : MyClass1, IMyInterface
    {
        T MyProperty { get; private set; }
        object IMyInterface.MyProperty { get { return MyProperty; }}
    }
