    // In the class scope
    int _count;
    int MaxCount;
    int Count
    {
        get { retrun _count; }
        set { _count = value; if(_count > MaxCount) MaxCount = value; }
    }
    ...
    Task.Factory.StartNew(() =>{ 
        Parallel.ForEach(list, new ParallelOptions { MaxDegreeOfParallelism = 10 }, (listitem, state) =>
        {
            Count++;
            Console.writeln(Process.GetCurrentProcess().Threads.Count);
            Count--;            
        });
    });
