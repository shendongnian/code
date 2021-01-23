    public string GetHtml(string url)
    {
        var html = "";
        using (var client = new WebClient())
        {
            // Assign all the important stuff
            client.Proxy = this.Proxy;
            client.Headers[HttpRequestHeader.UserAgent] = this.UserAgent;
            
            // Run DownloadString() as a task.
            var task = client.DownloadStringTaskAsync(url);
            // Wait for the task to finish, or timeout
            Task.WaitAll(new Task<string>[] { task }, this.Timeout);
            // If timeout was reached, cancel task and throw an exception.
            if (task.IsCompleted == false)
            {
                client.CancelAsync();
                throw new TimeoutException();
            }
            // Otherwise, happy. :)
            html = task.Result;
        }
