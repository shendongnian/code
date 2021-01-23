    static int count = 0;
    
    static Action GetWorker(int k)
    {
        return k == 0 ? (Action)(() => Console.WriteLine("Working 1 - {0}",count++))
                      : (Action)(() => Console.WriteLine("Working 2 - {0}",count++));
    }
