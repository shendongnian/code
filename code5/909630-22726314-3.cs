    static public Task<WebResponse> GetResponseTapAsync(this WebRequest request)
    {
        return Task.Factory.FromAsync(
             (asyncCallback, state) =>
                 request.BeginGetResponse(asyncCallback, state),
             (asyncResult) =>
                 request.EndGetResponse(asyncResult), null);
    }
    // ...
    public class YourController : AsyncController
    {
        public void YourMethodAsyc(string url)
        {
            AsyncManager.OutstandingOperations.Increment();
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.GetResponseTapAsync().ContinueWith(responseTask =>
            {
                try
                {
                    var stream = responseTask.Result.GetResponseStream();
                    using (var streamReader = new StreamReader(stream))
                    {
                        // still blocking here, see notes below
                        var data = streamReader.ReadToEnd();
                        AsyncManager.Parameters["data"] = data;
                    }
                }
                finally
                {
                    AsyncManager.OutstandingOperations.Decrement();
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        public ActionResult YourMethodCompleted(string data)
        {
            return View("Data", new ViewModel
            {
                Data = data
            });
        }
    }
