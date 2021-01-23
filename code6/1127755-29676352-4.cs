    public interface IFoo<out T> where T : class
    {
         T Data { get; }
    }
    public struct Foo<T> : IFoo<T> where T : class
    {
        public Foo(T data) : this()
        {
            Data = data;
        }
        public T Data { get; private set; }
    }
    public interface IFooService<out T> where T : class 
    {
        IFoo<T> Get(string id);
    }
    public class FooService<T> : IFooService<T> where T : class
    {
        ...
        public IFoo<T> Get(string id)
        {
            ...
        }
    }
