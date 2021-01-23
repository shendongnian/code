    private static async Task<MyObject> RunTask(Func<MyObject> task)
    {
        var watch = Stopwatch.StartNew();
        var result = await Task.Run(task);
        watch.Stop();
        result.ExecutionTimeInMs = watch.ElapsedMilliseconds;
        return result;
    }
