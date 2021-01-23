    using (var client = new HttpClient())
    {
        await Task.WhenAll(services.Select(x =>
        {
            return client.GetStringAsync(x.Url).ContinueWith(response =>
            {
                Console.WriteLine(response.Result);
            }, TaskContinuationOptions.AttachedToParent);
    
        }).ToArray())
        .ContinueWith(response => 
        {
            Console.WriteLine("All tasks completed");
        });
    }
