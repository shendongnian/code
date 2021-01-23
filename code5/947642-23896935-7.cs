    class ClosureClass
    {
        public TaskCompletionSource<dynamic> tcs;
        public async Task AnonymousMethod1(object s, 
            DownloadDataCompletedEventArgs a)
        {
            tcs.TrySetResult(await Newtonsoft.Json.JsonConvert.DeserializeObject(
                a.Result.ToString()));
        }
    }
    public Task<dynamic> GetWebStuff()
    {
        ClosureClass closure = new ClosureClass();
        closure.tcs = new TaskCompletionSource<dynamic>();
        WebClient wc = new WebClient();
        wc.DownloadStringCompleted += closure.AnonymousMethod1;
        wc.DownloadStringAsync(new Uri("http://www.MyJson.com"));
        return closure.tcs.Task;
    }
