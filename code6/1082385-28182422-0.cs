    public class MyViewModel
    {
      public int X
      {
        get { return x.Value; }
        private set { x.OnNext(value); }
      }
      public int Y
      {
        get { return y.Value; }
        private set { y.OnNext(value); }
      }
      public int Z
      {
        get { return z.Value; }
        private set { z.OnNext(value); }
      }
      private readonly BehaviorSubject<int> x = new BehaviorSubject<int>(0);
      private readonly BehaviorSubject<int> y = new BehaviorSubject<int>(0);
      private readonly BehaviorSubject<int> z = new BehaviorSubject<int>(0);
      public MyViewModel(IObservable<string> source)
      {
        var patterns = new Dictionary<string, IObserver<int>>()
        {
          { patternX, x },
          { patternY, y },
          { patternZ, z }
        };
        (from input in source
         from action in from pattern in patterns
                        let match = Regex.Match(input, pattern.Key)
                        where match.Success
                        let value = GetInt32Somehow(match.Value)
                        select new Action(() => pattern.Value.OnNext(value))
         select action)
         .Subscribe(action => action());
      }
    }
