    static void Main(string[] args)
    {
        const int numberOfTasks = 10;
    
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        var startTime = DateTime.Now.ToString("hh:mm:ss.fff tt");
    
        List<Task<string>> taskList = new List<Task<string>>();
    
        for(int i = 0; i < numberOfTasks; i++)
          taskList.Add(new Task<string> ( LdsConnection.Auth("username", "password", true) )
    
        foreach(var task in taskList)
          taskList.Start();
    
        foreach(var task in taskList)
          Console.WriteLine(task.Result);
    
        Console.ReadKey();
    }
