    List<Process> processes = new List<Process>();
    for each (DirectoryInfo di in directoryList)
    {
        for each (FileInfo fi in di.GetFiles())
        {
            processes.Add(MyTask(fi.FullName));
        }
    }
    foreach(Process p in processes)
    {
        p.WaitForExit();
    }
