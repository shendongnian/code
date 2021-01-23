    public static class WebRequestExtensions
    {
        public static async Task<WebResponse> GetResponseAsyncWithTimeout(this WebRequest request)
        {
            var timeoutCancellationTokenSource = new CancellationTokenSource();
            
            var responseTask = request.GetResponseAsync();
            var completedTask = await Task.WhenAny(responseTask, Task.Delay(request.Timeout, timeoutCancellationTokenSource.Token));
            if (completedTask == responseTask)
            {
                timeoutCancellationTokenSource.Cancel();
                return await responseTask;
            }
            else
            {
                request.Abort();
                throw new TimeoutException("The operation has timed out.");
            }
        }
    }
