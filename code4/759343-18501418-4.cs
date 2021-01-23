    public string AskAPI(string uri, int millis)
    {
        using (var task = new Task<string>(() => api.Query(uri)))
        {
            task.Start();
            task.Wait(millis);
            if (!task.IsCompleted) throw new TimeoutException();
            return task.Result;
        }   
    }
