CSharp
public class AsyncIndexer
{
    public Task<int> this[int i] => GetValue(i);
    public Task<string> this[string s] => Task.Run(async () =>
    {
        await Task.Delay(3000);
        return s;
    });
    private async Task<int> GetValue(int i)
    {
        await Task.Delay(3000);
        return i;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Task.Run(async () =>
        {
            var asyncIndexer = new AsyncIndexer();
            Console.WriteLine(await asyncIndexer[2]);
        }).Wait();
    }
}
Unfortunately setters can't return anything, so async setters are in no way possible because the await statement needs a task to be returned. 
Could you imagine the syntax? 
csharp 
await (asyncIndexer[2] = 2)
I'd love that :p
