    public class Foo : IDisposable
    {
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();
        public Foo()
        {
            Task.Run(async () => await CleanupAsync());
        }
        public void Dispose()
        {
            _tokenSource.Cancel();
        }
        public async Task CleanupAsync()
        {
            while (!_tokenSource.Token.IsCancellationRequested)
            {
               // Do whatever cleanup you need to.
               await Task.Delay(TimeSpan.FormSeconds(5),_tokenSource.Token);
            }
        }
    }
