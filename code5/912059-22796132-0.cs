    public static async Task<bool> CheckIfWebConnectionIsGoodAsync(TimeSpan? minResponseTime, Uri testUri)
    {
        if (minResponseTime == null)
        {
            minResponseTime = TimeSpan.FromSeconds(0.3);
        }
        if (testUri == null)
        {
            testUri = new Uri("http://www.google.com");
        }
        var client = new HttpClient();
        var cts = new CancellationTokenSource(minResponseTime.Value);
        try
        {
            var task = client.GetAsync(testUri).AsTask(cts.Token);
            await task;
            if (task.IsCanceled)
                return false;
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
