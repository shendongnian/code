    var client = new HttpClient();
    var tasks = services.Select(async x => new 
    {
        Service = x,
        ResponseText = await client.GetStringAsync(x.Url)
    }).ToList();
    while (tasks.Count > 0) 
    {
        var firstDone = await Task.WhenAny(tasks);
        tasks.Remove(firstDone);
        var result = await firstDone;
        Console.WriteLine(result.ResponseText);
        // do something with result.Service
    }
    Console.WriteLine("All tasks completed");
