    CancellationTokenSource source = new CancellationTokenSource();
    source.Cancel();
    HttpClient client = new HttpClient();
    var content = new ObjectContent(typeof (MyObject), new MyObject(), new JsonMediaTypeFormatter());
    content.LoadIntoBufferAsync().Wait();
    try
    {
        var task = client.PostAsync("http://server-address.com",content, source.Token);
        task.Wait();
    }
    catch (Exception ex)
    {
        //This will get hit now with an AggregateException containing a TaskCancelledException.
    }
        
