    var client = new HttpClient();
    var tasks = services.Select(x => client.GetStringAsync(x.Url)).ToList();
    while (tasks.Count > 0) {
        var firstDone = await Task.WhenAny(tasks);
        tasks.Remove(firstDone);
        Console.WriteLine(await firstDone);
    }
    Console.WriteLine("All tasks completed");
