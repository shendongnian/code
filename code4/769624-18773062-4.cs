    var tasks = new List<Task<int>>();
    var cts = new CancellationTokenSource();
    for (int i = 0; i < 10; i++)
    {
        int temp = i;
        tasks.Add(Task.Run(() =>
        {
            //placeholder for real work of variable time
            Thread.Sleep(1000 * temp);
            return i;
        }, cts.Token));
    }
    var value = Task.WaitAny(tasks.ToArray());
    cts.Cancel();
