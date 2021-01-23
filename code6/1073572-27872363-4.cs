    var completed = 0;
    foreach(Process p in processes)
    {
        Console.WriteLine("Waiting for processes to complete. Progress: {0}/{1}"
            completed, processes.Count);
        p.WaitForExit();
        completed++;        
    }
    Console.WriteLine("Done. All {0} processes are complete." processes.Count);
