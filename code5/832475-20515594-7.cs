    public interface IInterface1
    {
        string Bar1{ get; set; }
        string Bar2{ get; set; }
    }
    public interface IInterface2
    {
        IInterface1 Foo{ get; }
    }
    public interface IInterface3<T>:IInterface2 where T:IInterface1
    {
        new T Foo { get; set; } // hide the non-generic IInterface2.Foo
    }
    
    public class Class1<T> : IInterface3<T> where T : IInterface1
    {
        public T Foo { get; set; }
        IInterface1 IInterface2.Foo { get { return Foo; }} // explicitely implement IInterface2.Foo
    }
