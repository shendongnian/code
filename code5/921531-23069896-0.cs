    interface IFactory
    {
        Type GetType1();
    }
    namespace X
    {
        public class Type1 { }
        public class Factory : IFactory
        {
            public Type GetType1() { return typeof(Type1); }
        }
    }
    namespace Y
    {
        public class Type1 { }
        public class Factory : IFactory
        {
            public Type GetType1() { return typeof(Type1); }
        }
    }
    public void MyFunction<T>(T factory)
        where T : IFactory
    {
        var type = factory.GetType1();
        ...
    }
    void Main()
    {
        MyFunction(new X.Factory());
        MyFunction(new Y.Factory());
    }
