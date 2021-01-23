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
            request.GetResponseTapAsync().ContinueWith(t =>
            {
                try
                {
                    AsyncManager.Parameters["result"] = t.Result;
                }
                finally
                {
                    AsyncManager.OutstandingOperations.Decrement();
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        public ActionResult YourMethodCompleted(string[] result)
        {
            return View("Resut", new ViewModel
            {
                Result = result
            });
        }
    }
