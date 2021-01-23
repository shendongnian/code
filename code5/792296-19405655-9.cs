    {
        var count = Int32.Parse(Console.ReadLine());
        Console.Write("Logger Type -->");
        var logType = Console.ReadLine();
        Action<int> logAction;
        if (logType == "A")
        {
            if (count > 10)
            {
                logAction = LoggerTypeA.Error;
            }
            else
            {
                logAction = LoggerTypeA.Warning;
            }
        }
        else
        {
            if (count > 10)
            {
                logAction = LoggerTypeB.Error;
            }
            else
            {
                logAction = LoggerTypeB.Warning;
            }
        }
        logAction(count);
    
        Console.ReadLine();
    }
