    internal class Program
    {
        private static void Main()
        {
            bool useAsync = true;
            var tcs = new TaskCompletionSource<object>();
            Task previous = tcs.Task;
            for (var i = 0; i < 100000; ++i)
            {
                previous = useAsync ? DoSomethingUsingAsync(previous) : DoSomethingUsingContinuation(previous);
            }
            tcs.SetResult(null);
            previous.Wait();
        }
        private static Task DoSomethingUsingContinuation(Task previousTask)
        {
            return previousTask.ContinueWith(_ => { }, TaskContinuationOptions.ExecuteSynchronously);
        }
        private static async Task DoSomethingUsingAsync(Task previousTask)
        {
            await previousTask.ConfigureAwait(false);
            // Uncomment the next line to solve!
            // await Task.Yield();
        }
    }
