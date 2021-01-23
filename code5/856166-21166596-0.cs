    public Task CollectData()
    {
        var tasks = new List<Task>();
        foreach (string address in addresses)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://example.com:1337/");
            
            //Note we're collecting the resulting Task objects here
            //We're actually getting the task from the continuation, which is a little bit weird
            //Alternatively, you could break this into another method that uses await internally
            var task = client.GetAsync(address).ContinueWith(
                getTask =>
                    {
                        if (getTask.IsCanceled)
                        {
                            error();
                        }
                        else if(getTask.IsFaulted)
                        {
                            error();
                        }
                        else
                        {
                            requestsCompleted++;
                            checkFinished();
                        }
                    }
            );
            tasks.Add(task);
        }
        //Return a single task that completes when all the subtasks are done
        return Task.WhenAll(tasks.ToArray());
    }
