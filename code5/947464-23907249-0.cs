    public static class ObservableExtensions
    {
        public static IObservable<T> Pace<T>(this ConcurrentQueue<T> queue, TimeSpan interval)
        {
            var source = Observable.Create<T>(async (o, ct) => {
            
                T next;            
                while(!ct.IsCancellationRequested)
                {
                    while(queue.TryDequeue(out next))
                        o.OnNext(next);
                        
                    await Task.Delay(interval, ct);
                }   
                
                ct.ThrowIfCancellationRequested();
            });
        
            return source.Select(i => Observable.Empty<T>()
                        .Delay(interval)
                        .StartWith(i)).Concat();    
        }
    }
