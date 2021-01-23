    public async Task<bool> Init()
    {
        var series = Enumerable.Range(1, 5).ToList();
        var tasks = new List<Task<(int Index, bool IsDone)>>();
        foreach (var i in series)
        {
            Console.WriteLine("Starting Process {0}", i);
            tasks.Add(DoWorkAsync(i));
        }
        foreach (var task in await Task.WhenAll(tasks))
        {
            if (task.IsDone)
            {
                Console.WriteLine("Ending Process {0}", task.Index);
            }
        }
        return true;
    }
    public async Task<(int Index, bool IsDone)> DoWorkAsync(int i)
    {
        Console.WriteLine("working..{0}", i);
        await Task.Delay(1000);
        return (i, true);
    }
