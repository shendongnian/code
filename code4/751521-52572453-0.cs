    public static class Func {
       public static Func<T> Create<T>(
          Func<T> pFunc
       ) =>
         pFunc;       
    }
    ...
    x = Func.Create(() => "result")();
    x = Func.Create(() => {
       // complex logix to create a value
    })();
