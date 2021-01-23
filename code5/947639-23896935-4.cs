    public Task<dynamic> GetWebStuff()
    {
        var tcs = new TaskCompletionSource<dynamic>();
        WebClient wc = new WebClient();
        wc.DownloadStringCompleted += async (s, a) =>
        {
            tcs.TrySetResult(await Newtonsoft.Json.JsonConvert.DeserializeObject(
                a.Result.ToString()));
        };
        wc.DownloadString("http://www.MyJson.com");
        return tcs.Task;
    }
