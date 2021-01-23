    // Create an HttpClient and set the timeout for requests
    HttpClient client = new HttpClient();
    client.Timeout = TimeSpan.FromSeconds(10);
    // Issue a request
    client.GetAsync(_address).ContinueWith(
        getTask =>
         {
                if (getTask.IsCanceled)
                {
                  Console.WriteLine("Request was canceled");
                }
                else if (getTask.IsFaulted)
                {
                   Console.WriteLine("Request failed: {0}", getTask.Exception);
                }
                else
                {
                   HttpResponseMessage response = getTask.Result;
                   Console.WriteLine("Request completed with status code {0}", response.StatusCode);
                }
        });
