    public class Worker1
    {
        public IObservable<string> UpdateEvents { get; private set; };
        public Worker1()
        {
            // Each time someone subscribes, create a new worker2 and subscribe to the hot events as well as whatever worker2 produces.
            UpdateEvents = Observable.Create(observer =>
            {
                var worker2 = new Worker2();
                return incoming1.Merge(worker2.UpdateEvents).Subscribe(observer);
            });
        }
    }
    public class Worker2
    {
        public IObservable<string> UpdateEvents { get; private set; };
        public Worker2()
        {
            // Each time someone subscribes, create a new worker and subscribe to the hot events as well as whatever worker2 produces.
            UpdateEvents = Observable.Create(observer =>
            {
                // maybe this version needs to do some stuff after it has subscribed to incoming2 but before it subscribes to workerN:
                var doWorkThenSubscribeToWorker = Observable.Create(o =>
                {
                    DoWork(o);
                    var worker = new WorkerN();
                    return worker.UpdateEvents.Subscribe(o);
                }
                return incoming2.Merge(doWorkThenSubscribeToWorker).Subscribe(observer);
            });
        }
        private void DoWork(IObserver<string> observer)
        {
            // do some work
            observer.OnNext("result of work");
        }
    }
    void Main()
    {
        var worker = new Worker();
        worker.UpdateEvents.Do(x => Console.WriteLine()).Wait();
    }
