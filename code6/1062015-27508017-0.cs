    public class Foo
    {
        private ConcurrentDictionary<RepModel, CancellationTokenSource> tokenLookup =
            new ConcurrentDictionary<RepModel, CancellationTokenSource>();
        public async Task Start(RepModel model)
        {
            var cts = new CancellationTokenSource();
            tokenLookup[model] = cts;
            while (!cts.IsCancellationRequested)
            {
                await Task.Run(() => model.DoWork());
                await Task.Delay(TimeSpan.FromMinutes(1));
            }
        }
        public void End(RepModel model)
        {
            CancellationTokenSource cts;
            if (tokenLookup.TryRemove(model, out cts))
                cts.Cancel();
        }
    }
