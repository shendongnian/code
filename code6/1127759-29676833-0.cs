    public interface IFoo
    {
        object Data { get; }
    }
    public interface IFoo<T> : IFoo
    {
        new T Data { get; }
    }
    public class Foo<T> : IFoo<T>
    {
        public Foo(T data) { Data = data; }
        public T Data { get; private set; }
        object IFoo.Data { get { return Data; } }
    }
    public interface IFooService
    {
        IFoo Get(string id);
    }
    public interface IFooService<T> : IFooService
    {
        new IFoo<T> Get(string id);
    }
    public class FooService<T> : IFooService<T>
    {
        public IFoo<T> Get(string id) { return null; }
        IFoo IFooService.Get(string id) { return Get(id); }
    }
