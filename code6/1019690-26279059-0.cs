    private static void Main()
    {
      var source = new Subject<int>();
      source
        .Materialize()
        .SelectIfOk(Process1)
        .SelectIfOk(Process2)
        .Subscribe(it =>
          Console.WriteLine(it.HasValue
            ? it.Value.ToString()
            : it.Exception != null ? it.Exception.Message : "Completed."));
      source.OnNext(1);
      source.OnNext(2);
      source.OnNext(3);
      source.OnNext(4);
      source.OnNext(5);
      source.OnCompleted();
      Console.ReadLine();
    }
    private static int Process1(int value)
    {
      if (value == 3)
        throw new Exception("error 1");
      // do some processing
      return value * 2;
    }
    private static string Process2(int value)
    {
      if (value == 4)
        throw new Exception("error 2");
      // do some processing
      return value + " good";
    }
    private static IObservable<Notification<TR>> SelectIfOk<T, TR>(this IObservable<Notification<T>> stream,
      Func<T, TR> selector)
    {
      Func<T, Notification<TR>> trySelector = it =>
      {
        try
        {
          var value = selector(it);
          return Notification.CreateOnNext(value);
        }
        catch (Exception ex)
        {
          return Notification.CreateOnError<TR>(ex);
        }
      };
      return stream.Select(it =>
        it.HasValue
          ? trySelector(it.Value)
          : it.Exception != null
            ? Notification.CreateOnError<TR>(it.Exception)
            : Notification.CreateOnCompleted<TR>());
    }
