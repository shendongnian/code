    class SomeClass<T>
    {
      public static Result<T> Pass(T value)
      {
          return new Result<T>()
          {
              Passed = true,
              Value = value
          };
      }
    }
