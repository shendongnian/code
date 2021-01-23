    // contract
    [ServiceContract]
    public interface IService
    {
        //task-based asynchronous pattern
        [OperationContract]
        Task<bool> DoLongPolling(string url, int delay, int timeout);
    }
    // implementation
    public class Service : IService
    {
        public async Task<bool> DoLongPollingAsync(
            string url, int delay, int timeout)
        {
            // handle timeout via CancellationTokenSource
            using (var cts = new CancellationTokenSource(timeout))
            using (var httpClient = new System.Net.Http.HttpClient())
            using (cts.Token.Register(() => httpClient.CancelPendingRequests()))
            {
                try
                {
                    while (true)
                    {
                        // do the polling iteration
                        var data = await httpClient.GetStringAsync(url).ConfigureAwait(false);
                        if (data == "END POLLING") // should we end polling?
                            return true;
                        // pause before the next polling iteration
                        await Task.Delay(delay, cts.Token);
                    }
                }
                catch (OperationCanceledException)
                {
                    // is cancelled due to timeout?
                    if (!cts.IsCancellationRequested)
                        throw;
                }
                // timed out
                throw new TimeoutException();
            }
        }
    }
