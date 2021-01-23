    public class Foo<T> {
      public T Data { get; private set; }
      public static Foo<T> Create(T value)
      {
         return new Foo<T> { Data = value };
      }
	
      public static Foo<int> From(int value)
      {
         return new Foo<int> { Data = 42 * value };
      }
    }
