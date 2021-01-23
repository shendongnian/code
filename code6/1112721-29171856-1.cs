    void Main()
    {
      IFoo<object> foo = new Foo<string>();
      Console.WriteLine(foo.Get());
    }
    
    interface IFoo<out T>
    {
      T Get();
    }
    
    class Foo<T> : IFoo<T>
    {
      T _store;
      public T Get()
      {
        _store = default(T);
        return _store;
      }
    }
