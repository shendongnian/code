    using System;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Threading.Tasks;
    namespace RxLabs.Net45
    {
      class PublishFinallyLab
      {
        public static void Main()
        {
          var obsOrCancellation = new Subject<int>();
    
          var obs = Observable.Create<int>(
                async (observer, cancel) =>
                {
                  observer.OnNext(1);
    
                  await Task.Delay(TimeSpan.FromSeconds(2), cancel).ConfigureAwait(false);
    
                  if (!cancel.IsCancellationRequested)
                  {
                    observer.OnNext(2);
                  }
                })
                .Finally(obsOrCancellation.OnCompleted)
                .Publish();
    
          obs.Subscribe(obsOrCancellation);
    
          var o1 = obsOrCancellation
                .Finally(() => Console.WriteLine("Finally!"))
                .Subscribe(
                  x => Console.WriteLine("Next: {0}", x),
                  ex => Console.WriteLine("Error: {0}", ex),
                  () => Console.WriteLine("Completed"));
    
          do
          {
            using (var connection = obs.Connect())
            {
              Console.WriteLine("Press any key to cancel.");
              Console.ReadKey();
            }
        
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
          }
          while (true);
        }
      }
    }
