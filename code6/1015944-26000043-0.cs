    static async Task<int> foo()
    { 
        Task<int> winningTask = await Task.WhenAny(Delay1(), Delay2(), Delay3());
        return await winningTask;
    }
    static void Main(string[] args)
    {           
        Console.WriteLine("Done");
        Console.WriteLine(foo().Result);
        Console.WriteLine(Delay1().Result);
    }
