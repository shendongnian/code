    HttpClient client = new HttpClient();
    var cts = new CancellationTokenSource();
    cts.CancelAfter(10000);
    string result = null;
    var task = Task.Run(async () => result = await client.GetStringAsync(
        new Uri(string.Format(url + "?loginas=" + login + "&pass=" + pwd))), 
        cts.Token);
    
    while(task.Status != TaskStatus.RanToCompletion && !cts.Token.IsCancellationRequested)
        await Task.Delay(10);
    if(task.Status != TaskStatus.RanToCompletion)
    {
        // failure handling
    }
    else
    {
        // use result
    }
