    HttpClient client = new HttpClient();
    var cts = new CancellationTokenSource();
    cts.CancelAfter(10000);
    try
    {
        var response = await client.GetAsync(new Uri(string.Format(url + 
                "?loginas=" + login + "&pass=" + pwd)), cts.Token);
        var result = await response.Content.ReadAsStringAsync();
        // work with result
    }
    catch(TaskCanceledException)
    {
        // error/timeout handling
    }
