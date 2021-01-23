    public static Task<byte[]> PostDataAsync(string url, NameValueCollection parameters, object state)
    {
        var tcs = new TaskCompletionSource<byte[]>(state: state);
        var client = new WebClient();
        client.UploadValuesCompleted += (obj, args) =>
        {
            if (args.Cancelled)
                tcs.SetCanceled();
            else if (args.Error != null)
                tcs.SetException(args.Error);
            else
                tcs.SetResult(args.Result);
        };
        client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
        client.UploadValuesAsync(new Uri(url), null, parameters, state);
        return tcs.Task;
    }
