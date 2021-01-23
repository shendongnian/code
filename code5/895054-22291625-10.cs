    void GetThreePagesV1()
    {
        var httpClient = new HttpClient();
        var finalTask = httpClient.GetStringAsync("http://example.com")
            .ContinueWith((task1) =>
            {
                var page1 = task1.Result;
                return httpClient.GetStringAsync("http://example.net")
                    .ContinueWith((task2) =>
                    {
                        var page2 = task2.Result;
                        return httpClient.GetStringAsync("http://example.org")
                            .ContinueWith((task3) =>
                            {
                                var page3 = task3.Result;
                                return page1 + page2 + page3;
                            }, TaskContinuationOptions.ExecuteSynchronously);
                    }, TaskContinuationOptions.ExecuteSynchronously).Unwrap();
            }, 
            TaskContinuationOptions.ExecuteSynchronously)
                .Unwrap()
                .ContinueWith((resultTask) =>
                {
                    httpClient.Dispose();
                    string result = resultTask.Result;
                    try
                    {
                        MessageBox.Show(result);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }, 
                CancellationToken.None, 
                TaskContinuationOptions.None, 
                TaskScheduler.FromCurrentSynchronizationContext());
    }
