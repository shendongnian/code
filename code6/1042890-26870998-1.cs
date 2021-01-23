    // In the class scope
    int _count = 0;
    int MaxCount = 0;
    object key = new object();
    int Count
    {
        get { lock(key) return _count; }
        set
        {
            lock(key)
            {
                _count = value;
                if(_count > MaxCount) MaxCount = value;
            }
        }
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
