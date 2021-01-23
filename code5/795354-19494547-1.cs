    static IObservable<int> Range(int start, int count, IScheduler scheduler)
    {
        return Observable.Create<int>(observer =>
        {
            return scheduler.Schedule(0, (i, self) =>
            {
                if (i < count)
                {
                    Console.WriteLine("Iteration {0}", i);
                    observer.OnNext(start + i);
                    self(i + 1); /* Here is the recursive call */
                }
                else
                {
                    observer.OnCompleted();
                }
            });
        });
    }
