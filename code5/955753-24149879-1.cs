     List<Task<ResponseOBJ>> tasks = new List<Task<ResponseOBJ>>();
        // get List of rssProviders
     string[] providers = request.requestBody.rssProvider.Split(',');
        //go through each provider
        foreach (string provider in providers)
        {
            Task<ResponseOBJ> task = Task.Factory.StartNew<ResponseOBJ>(() =>
                {
                    request.requestBody.rssProvider = provider;
                    var newRequest = new Request(request);               
                    doStuff(newRequest);
                }
            tasks.Add(task);
        }
        Task.WaitAll(tasks.ToArray());    
