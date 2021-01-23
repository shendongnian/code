    private static Task GetAsync<T>(HttpClient httpClient, Uri URI, Action<Task<T>> continuationAction)
    {
        return httpClient.GetAsync(URI)
            .ContinueWith(request =>
            {
                request.Result.EnsureSuccessStatusCode();
    
                request.Result.Content.ReadAsAsync<T>()
                    .ContinueWith(continuationAction);
            });
    }
