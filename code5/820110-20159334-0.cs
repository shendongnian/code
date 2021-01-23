    using System.Runtime.CompilerServices;
    public static void Main(string[] args)
    {
        Test().Wait();            
    }
    
    private static async Task Test()
    {
        await Task.Yield();
        Log();
        await Task.Yield();
    }
    
    private static void Log([CallerMemberName]string name = "")
    {
        Console.WriteLine("Log: {0}", name);
    }
