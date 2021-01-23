    Process currentProcess = Process.GetCurrentProcess();
    ProcessPriorityClass oldPriority = currentProcess.PriorityClass;
    try
    {
        //Lower the priority of the current process
        currentProcess.PriorityClass = ProcessPriorityClass.BelowNormal;
        //Do your low priority CPU intensive work here.
    }
    finally
    {
        //Bring the priority back up to the original level.
        currentProcess.PriorityClass = oldPriority;
    }
