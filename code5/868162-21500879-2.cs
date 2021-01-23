    private static Task<HttpWebResponse> GetResponseAsync(WebRequest request)
    {
        var taskComplete = new TaskCompletionSource<HttpWebResponse>();
        request.BeginGetResponse(asyncResponse =>
        {
            try
            {
                HttpWebRequest responseRequest = (HttpWebRequest)asyncResponse.AsyncState;
                HttpWebResponse someResponse = (HttpWebResponse)responseRequest.EndGetResponse(asyncResponse);
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
