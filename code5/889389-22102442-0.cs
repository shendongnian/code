    interface IHasPropertyValue {
      string Value { get; }
    }
    class MyType<T> : where T : IHasPropertyValue {
      public void Method(T obj) {
        Console.WriteLine(obj.Value);
      }
    }
