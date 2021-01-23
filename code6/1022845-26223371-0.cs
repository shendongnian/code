    Task<WebResponse> task = Task.Factory.FromAsync(
        request.BeginGetResponse,
        asyncResult => { callback(asyncResult); },
        (object)null);
    return task.ContinueWith(t =>
    {
    if (t.IsFaulted)
    {
        //handle error
        Exception firstException = t.Exception.InnerExceptions.First();
    }
    else
    {
        return FinishWebRequest(t.Result);
    }
    });
