    public interface IFoo<out T> 
    {
         T Data { get; }
    }
    public class Foo<T> : IFoo<T> 
    {
        public Foo(T data)
        {
            Data = data;
        }
        public T Data { get; private set; }
    }
    public interface IFooService<out T> 
    {
        IFoo<T> Get(string id);
    }
    public class FooService<T> : IFooService<T>
    {
        ...
        public IFoo<T> Get(string id)
        {
            ...
        }
    }
