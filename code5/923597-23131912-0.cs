    WebClient webClient = new WebClient();
    var cts = new CancelationTokenSource();
    cts.CancelAfter(10000);
    string result = null;
    var task = Task.Run(() => result = webClient.DownloadStringAsync(
        new Uri(string.Format(url + "?loginas=" + login + "&pass=" + pwd))),
        cts.Token);
    
    while(task.State == TaskState.Running && !cts.Token.IsCancelationRequested)
        await Task.Delay(10);
    if(task.State == TaskState.Running)
    {
        task.Abort();
        // failure handling
    }
    else
    {
        // use result
    }
