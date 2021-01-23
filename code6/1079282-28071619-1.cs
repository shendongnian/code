    IObservable<Result> Calculate(IScheduler scheduler)
    {
      return Observable.Create<Result>(observer => 
        scheduler.Schedule(() =>
        {
           observer.OnNext(longPartialCalculation());
           observer.OnNext(morePartialCalculation());
           observer.OnNext(moreWork());
           observer.OnCompleted();
        }));
    }
    
    // Depending upon your needs, you could use inheritance as follows:
    public abstract class Result { ... }
    public class MidResult1 : Result { ... }
    public class MidResult2 : Result { ... }
    public class FinalResultObject : Result { ... }
