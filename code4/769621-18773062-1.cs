    public static async Task<int> Foo()
    {
        var tasks = new List<Task<int>>();
        var cts = new CancellationTokenSource();
        for (int i = 0; i < 10; i++)
        {
            int temp = i;
            tasks.Add(Task.Run(async () =>
            {
                await Task.Delay(1000 * temp, cts.Token);
                return temp;
            }));
        }
        var value = await await Task.WhenAny(tasks);
        cts.Cancel();
        return value;
    }
