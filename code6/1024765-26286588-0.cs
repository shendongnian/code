    using System;
    using System.Threading.Tasks;
    using System.Diagnostics;
    public class Program
    {
    	public static void Main()
    	{
    		Task t = new Program().TestTasks();
    		Console.WriteLine("hello");
    		t.Wait();
    	}
    
    	public async Task TestTasks()
    	{
    		Stopwatch watch = Stopwatch.StartNew();
    		Console.WriteLine("1." + watch.ElapsedMilliseconds);
    		// await task, nothing after
    		int res = await TestAsync();
    		Console.WriteLine("2." + watch.ElapsedMilliseconds + " " + res);
    		// save task and wait on it
    		Task<int> t = TestAsync();
    		t.ContinueWith((r) =>
    		{
    			Console.WriteLine("4." + watch.ElapsedMilliseconds + " " + r.Result);
    		});
    		Console.WriteLine("3." + watch.ElapsedMilliseconds);
    		t.Wait();
    	}
    
    	public static async Task<int> TestAsync()
    	{
    		await Task.Delay(TimeSpan.FromSeconds(2));
    		return 42;
    	}
    }
