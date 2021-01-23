    public class Consumer
    {
        private readonly Service _service = new Service();
        public IObservable<string> Trigger()
        {
            var connectible = Observable.Timer(TimeSpan.FromMilliseconds(100))
                .SelectMany(_ => RunAsync())
                .Replay();
            connectible.Connect();
            return connectible;
        }
        public Task<string> RunAsync()
        {
            return _service.DoAsync();
        }
    }
