    public static class ObservableExtensions
    {
        public static IObservable<T> Pace<T>(this ConcurrentQueue<T> queue,
                                             TimeSpan interval)
        {
            var source = Observable.Create<T>(async (o, ct) => {
            
                T next;            
                while(!ct.IsCancellationRequested)
                {
                    while(queue.TryDequeue(out next))
                        o.OnNext(next);
                    
                    // You might want to use some arbitrary shorter interval here
                    // to allow the stream to resume after a long delay in source
                    // events more promptly    
                    await Task.Delay(interval, ct);
                }   
                
                ct.ThrowIfCancellationRequested();
            });
        
            // this does the pacing
            return source.Select(i => Observable.Empty<T>()
                        .Delay(interval)
                        .StartWith(i)).Concat();    
        }
    }
