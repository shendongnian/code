    public static IObservable<T> Spy<T>(this IObservable<T> source, string opName = null)
    {
        opName = opName ?? "IObservable";
        Console.WriteLine("{0}: Observable obtained on Thread: {1}",
                          opName,
                          Thread.CurrentThread.ManagedThreadId);
        return Observable.Create<T>(obs =>
            {
                Console.WriteLine("{0}: Subscribed to on Thread: {1}",
                                  opName,
                                  Thread.CurrentThread.ManagedThreadId);
                try
                {
                    return source
                        .Do(x => Console.WriteLine("{0}: OnNext({1}) on Thread: {2}",
                                                    opName,
                                                    x,
                                                    Thread.CurrentThread.ManagedThreadId),
                            ex => Console.WriteLine("{0}: OnError({1}) on Thread: {2}",
                                                     opName,
                                                     ex,
                                                     Thread.CurrentThread.ManagedThreadId),
                            () => Console.WriteLine("{0}: OnCompleted() on Thread: {1}",
                                                     opName,
                                                     Thread.CurrentThread.ManagedThreadId)
                        )
                        .Subscribe(obs);
                }
                finally
                {
                    Console.WriteLine("{0}: Subscription completed.", opName);
                }
            });
    }
