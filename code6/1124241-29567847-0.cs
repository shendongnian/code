    public static class ObservableExtensions
    {
        public static IObservable<TSource> MergeWithLowPriorityStream<TSource>(
            this IObservable<TSource> source,
            IObservable<TSource> lowPriority,
            IScheduler scheduler = null)
        {    
            scheduler = scheduler ?? Scheduler.Default;
            return Observable.Create<TSource>(o => {    
                // BufferBlock from TPL dataflow is used as it is
                // handily awaitable. package: Microsoft.Tpl.Dataflow        
                var loQueue = new BufferBlock<TSource>();
                var hiQueue = new BufferBlock<TSource>();
                var errorQueue = new BufferBlock<Exception>();
                var done = new TaskCompletionSource<int>();
                int doneCount = 0;
                Action incDone = () => {
                    var dc = Interlocked.Increment(ref doneCount);
                    if(dc == 2)
                        done.SetResult(0);
                };
                source.Subscribe(
                    x => hiQueue.Post(x),
                    e => errorQueue.Post(e),
                    incDone);
                lowPriority.Subscribe(
                    x => loQueue.Post(x),
                    e => errorQueue.Post(e),
                    incDone);
                return scheduler.ScheduleAsync(async(ctrl, ct) => {
                    while(!ct.IsCancellationRequested)
                    {
                        TSource nextItem;
                        if(hiQueue.TryReceive(out nextItem)
                          || loQueue.TryReceive(out nextItem))
                            o.OnNext(nextItem);
                            
                        else if(done.Task.IsCompleted)
                        {
                            o.OnCompleted();
                            return;
                        }
                            
                        Exception error;                        
                        if(errorQueue.TryReceive(out error))
                        {
                            o.OnError(error);
                            return;
                        }
                            
                        var hiAvailableAsync = hiQueue.OutputAvailableAsync(ct);    
                        var loAvailableAsync = loQueue.OutputAvailableAsync(ct);                    
                        var errAvailableAsync =
                            errorQueue.OutputAvailableAsync(ct);
                        await Task.WhenAny(
                            hiAvailableAsync,
                            loAvailableAsync,
                            errAvailableAsync,
                            done.Task);
                    }
                });
            });
        }
    }
