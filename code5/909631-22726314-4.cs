    public class YourController : AsyncController
    {
        async Task<string> YourMethodAsyncImpl(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            using (var response = await request.GetResponseAsync()
            using (var streamReader = new StreamReader(response.GetResponseStream())
                return await streamReader.ReadToEndAsync();
        }
        public void YourMethodAsyc(string url)
        {
            AsyncManager.OutstandingOperations.Increment();
            YourMethodAsyncImpl(url).ContinueWith(resultTask =>
            {
                try
                {
                    AsyncManager.Parameters["data"] = resultTask.Result;
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
