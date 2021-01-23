 C#
public static class ParallelAsync
{
    public static async Task ForeachAsync<T>(IEnumerable<T> source, int maxParallelCount, Func<T, Task> action)
    {
        using (SemaphoreSlim semaphoreSlim = new SemaphoreSlim(maxParallelCount))
        {
            foreach (var item in source)
            {
                await semaphoreSlim.WaitAsync();
                Task.Run(async () =>
                {
                    try
                    {
                        await action(item);
                    }
                    finally
                    {
                        semaphoreSlim.Release();
                    }
                }).GetHashCode();
            }
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
    Console.WriteLine(item);
    await Task.Delay(random.Next(1500, 3000));
});
any suggestion please let me know.
