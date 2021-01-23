    public class Wrapper<T>
    {
        public T Value {get;set;}
    }
    internal MySecondDataType(Wrapper<MyFirstDataType> arg) { }
