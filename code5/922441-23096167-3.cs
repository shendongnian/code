    public static class HttpExtensions
    {
        public static Task<Stream> GetRequestStreamAsync(this HttpWebRequest request)
        {
            var tcs = new TaskCompletionSource<Stream>();
            try
            {
                request.BeginGetRequestStream(iar =>
               {
                   try
                   {
                       var response = request.EndGetRequestStream(iar);
                       tcs.SetResult(response);
                   }
                   catch (Exception exc)
                   {
                       tcs.SetException(exc);
                   }
               }, null);
            }
            catch (Exception exc)
            {
                tcs.SetException(exc);
            }
            return tcs.Task;
        }
        public static Task<HttpWebResponse> GetResponseAsync(this HttpWebRequest request)
        {
            var taskComplete = new TaskCompletionSource<HttpWebResponse>();
            request.BeginGetResponse(asyncResponse =>
            {
                try
                {
                    HttpWebRequest responseRequest = (HttpWebRequest)asyncResponse.AsyncState;
                    HttpWebResponse someResponse =
                       (HttpWebResponse)responseRequest.EndGetResponse(asyncResponse);
                    taskComplete.TrySetResult(someResponse);
                }
                catch (WebException webExc)
                {
                    HttpWebResponse failedResponse = (HttpWebResponse)webExc.Response;
                    taskComplete.TrySetResult(failedResponse);
                }
            }, request);
            return taskComplete.Task;
        }
    }
