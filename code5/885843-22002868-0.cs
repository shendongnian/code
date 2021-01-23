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
            var stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            using (var httpClient = new System.Net.Http.HttpClient())
            {
                while (true)
                {
                    // handle timeout
                    if (stopWatch.ElapsedMilliseconds >= timeout)
                        throw new TimeoutException(); // or return false
                    // do the polling iteration
                    var data = await httpClient.GetStringAsync(url);
                    if (data == "END POLLING") // should we end polling?
                        return true;
                    // pause before the next polling iteration
                    await Task.Delay(delay);
                }
            }
        }
    }
