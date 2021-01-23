    public class MyObserver
    {
        private readonly string _name;
        public MyObserver(string name) { _name = name; }
        public IObservable<Unit> Handle(IObservable<MyXmlDataFromWeb source)
        {
            return source.Select(value =>
            {
                Thread.Sleep(5000); // simulate work
                return Unit.Default;
            });
        }
    }
    // main
    var endSignal = new Subject<Unit>();
    var dataSource = Observable
        .Interval(...)
        .Select(...)
        .TakeUntil(endSignal)
        .Publish();
    var observer1 = new MyObserver("Observer 1");
    var observer2 = new MyObserver("Observer 2");
    var results1 = observer1.Handle(dataSource.ObserveOn(...));
    var results2 = observer2.Handle(dataSource.ObserveOn(...));
    // since you just want to know when they are all done
    // just merge them.
    // use ToTask() to subscribe them and collect the results
    // as a Task
    var processingDone = results1.Merge(results2).Count().ToTask();
    dataSource.Connect();
    Console.WriteLine("Press any key to cancel ...");
    Console.ReadLine();
    // end the stream
    endSignal.OnNext(Unit.Default);
    // wait for the processing to complete.
    // use await, or Task.Result
    var numProcessed = await processingDone;
