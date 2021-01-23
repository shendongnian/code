    using System;
    using System.Reactive.Concurrency;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    
    namespace SchedulerExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                var mydata = new[] {"A", "B", "C", "D", "E"};
                var observable = Observable.Create<string>(observer =>
                                                {
                                                    Console.WriteLine("Observable.Create");
                                                    return mydata.ToObservable().
                                                        Subscribe(observer);
                                                });
    
                observable.
                    SubscribeOn(new MyScheduler(ConsoleColor.Red)).
                    ObserveOn(new MyScheduler(ConsoleColor.Blue)).
                    Subscribe(s => Console.WriteLine("OnNext {0}", s));
    
                Console.ReadKey();
            }
        }
    }
