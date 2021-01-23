    void GetThreePagesV2()
    {
        Iterate(GetThreePagesHelper()).ContinueWith((iteratorTask) =>
            {
                try
                {
                    var lastTask = (Task<string>)iteratorTask.Result;
                    var result = lastTask.Result;
                    MessageBox.Show(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            },
            CancellationToken.None,
            TaskContinuationOptions.None,
            TaskScheduler.FromCurrentSynchronizationContext());
    }
    IEnumerable<Task> GetThreePagesHelper()
    {
        // now you can use "foreach", "using" etc
        using (var httpClient = new HttpClient())
        {
            var task1 = httpClient.GetStringAsync("http://example.com");
            yield return task1;
            var page1 = task1.Result;
            var task2 = httpClient.GetStringAsync("http://example.net");
            yield return task2;
            var page2 = task2.Result;
            var task3 = httpClient.GetStringAsync("http://example.org");
            yield return task3;
            var page3 = task3.Result;
            yield return Task.Delay(1000);
            var resultTcs = new TaskCompletionSource<string>();
            resultTcs.SetResult(page1 + page1 + page3);
            yield return resultTcs.Task;
        }
    }
    /// <summary>
    /// A slightly modified version of Iterate from 
    /// http://blogs.msdn.com/b/pfxteam/archive/2010/11/21/10094564.aspx
    /// </summary>
    public static Task<Task> Iterate(IEnumerable<Task> asyncIterator)
    {
        if (asyncIterator == null)
            throw new ArgumentNullException("asyncIterator");
        var enumerator = asyncIterator.GetEnumerator();
        if (enumerator == null)
            throw new InvalidOperationException("asyncIterator.GetEnumerator");
        var tcs = new TaskCompletionSource<Task>();
        Action<Task> nextStep = null;
        nextStep = (previousTask) =>
        {
            if (previousTask != null && previousTask.Exception != null)
                tcs.SetException(previousTask.Exception);
            if (enumerator.MoveNext())
            {
                enumerator.Current.ContinueWith(nextStep,
                    TaskContinuationOptions.ExecuteSynchronously);
            }
            else
            {
                tcs.SetResult(previousTask);
            }
        };
        nextStep(null);
        return tcs.Task;
    }
