 C#
public static class ParallelAsync
{
    public static async Task ForeachAsync<T>(IEnumerable<T> source, int maxParallelCount, Func<T, Task> action)
    {
        using (SemaphoreSlim completeSemphoreSlim = new SemaphoreSlim(1))
        using (SemaphoreSlim taskCountLimitsemaphoreSlim = new SemaphoreSlim(maxParallelCount))
        {
            await completeSemphoreSlim.WaitAsync();
            int runningtaskCount = 0;
            foreach (var item in source)
            {
                await taskCountLimitsemaphoreSlim.WaitAsync();
                Interlocked.Increment(ref runningtaskCount);
                Task.Run(async () =>
                {
                    try
                    {
                        await action(item).ContinueWith(task =>
                        {
                            Interlocked.Decrement(ref runningtaskCount);
                            if (runningtaskCount == 0)
                            {
                                completeSemphoreSlim.Release();
                            }
                        });
                    }
                    finally
                    {
                        taskCountLimitsemaphoreSlim.Release();
                    }
                }).GetHashCode();
            }
            await completeSemphoreSlim.WaitAsync();
        }
    }
}
usage:
 C#
string[] a = new string[] {
    "1",
    "2",
    "3",
    "4",
    "5",
    "6",
    "7",
    "8",
    "9",
    "10",
    "11",
    "12",
    "13",
    "14",
    "15",
    "16",
    "17",
    "18",
    "19",
    "20"
};
Random random = new Random();
await ParallelAsync.ForeachAsync(a, 2, async item =>
{
    Console.WriteLine(item + " start");
    await Task.Delay(random.Next(1500, 3000));
    Console.WriteLine(item + " end");
});
Console.WriteLine("All finished");
any suggestion please let me know.
