    using (var httpClient = new HttpClient())
    {
        Func<Task<IEnumerable<Foo>>> doTask1Async = async () =>
        {
            var request = await httpClient.GetAsync(new Uri("..."));
            return response.Content.ReadAsAsync<IEnumerable<Foo>>();
        };
        Func<Task<IEnumerable<Bar>>> doTask2Async = async () =>
        {
            var request = await httpClient.GetAsync(new Uri("..."));
            return response.Content.ReadAsAsync<IEnumerable<Bar>>();
        };
        var task1 = doTask1Async();
        var task2 = doTask2Async();
        await Task.WhenAll(task1, task2);
        var result1 = task1.Result;
        var result2 = task2.Result;
        // ...
    }
 
