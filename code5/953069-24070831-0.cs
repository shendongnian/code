    public static IObservable<IType> SomeTimerOperatorHere(
      this IObservable<SomeEvent> source)
    {
      var delay = TimeSpan.FromSeconds(1);
    
      return Observable.Create<IType>(o => {
        
        var sourcePub = source.Publish().RefCount();
        return sourcePub
          .Where(x => x.OriginalInput == 2)
          .SelectMany(type => 
            Observable.Return(new TimeEvent{ OriginalInput = 6 })
                      .Delay(delay)
                      .TakeUntil(sourcePub.Where(x => x.OriginalInput == 5))
          ).Subscribe(o);
      });
    }
        
