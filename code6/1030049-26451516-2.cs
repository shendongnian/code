    static void Main(string[] args)
    {
        var task = Task.Run(() => DoSomething());
        
        for (int i = 0; i < 1000; i++)
            Console.Write(".");
            
        task.Wait() 
    }
    static void DoSomething()
    {
        for (int i = 0; i < 1000; i++)
            Console.Write("X");
    }
