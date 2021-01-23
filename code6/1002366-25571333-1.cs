    private async Task<TReturnType> Post<TReturnType>(WebClient webClient, Uri uri, string jsonData)
    {
        TReturnType returnObject = default(TReturnType);
        var taskCompletionSource = new TaskCompletionSource<TReturnType>();
        UploadStringCompletedEventHandler handler = null;
        handler = (s, e) =>
        {
            webClient.UploadStringCompleted -= handler;
            var result = e.Result;
            try
            {
                Debug.WriteLine(result);
                returnObject = JsonConvert.DeserializeObject<TReturnType>(result);
                taskCompletionSource.SetResult(returnObject);
            }
            catch (Exception ex)
            {
                var newEx = new Exception(
                  string.Format("Failed to deserialize server response: {0}", result), ex);
                taskCompletionSource.SetException(newEx);
            }
        };
        webClient.UploadStringCompleted += handler;
        webClient.UploadStringAsync(uri, "POST", jsonData);
        return taskCompletionSource.Task;
    }
