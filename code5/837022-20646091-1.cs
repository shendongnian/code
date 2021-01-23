    Process currentProcess = Process.GetCurrentProcess();
    ProcessPriorityClass oldPriority = currentProcess.PriorityClass;
    try
    {
        currentProcess.PriorityClass = ProcessPriorityClass.BelowNormal;
        int i = 0;
        ThreadSafeRNG r = new ThreadSafeRNG();
        ParallelOptions.MaxDegreeOfParallelism = 4; //Assume I have 8 cores.
        Parallel.For(0, Int32.MaxValue, (j, loopState) => 
        {
            int k = r.Next();
            if (k > i) k = i;
        }
    }
    finally
    {
        //Bring the priority back up to the original level.
        currentProcess.PriorityClass = oldPriority;
    }
