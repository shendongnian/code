    using (var srvman = new ServerManager())
    {
        var procs = from worker in srvman.WorkerProcesses
                    let workerProcess = Process.GetProcessById(worker.ProcessId)
                    join cgi in Process.GetProcessesByName("php-cgi.exe")
                        on workerProcess.Id equals ParentProcessUtilities.GetParentProcess(cgi.Handle).Id
                        into childProcesses
                    select new
                    {
                        Worker = worker,
                        WorkerProcess = workerProcess,
                        Children = childProcesses,
                        TotalMemoryUse = workerProcess.PrivateMemorySize64
                            + childProcesses.Sum(p => p.PrivateMemorySize64)
                    };
        foreach (var proc in procs)
        {
            Console.WriteLine("Worker {0}:{1} using {2} bytes", proc.Worker.AppPoolName,
                proc.Worker.ProcessId, proc.TotalMemoryUse);
        }
    }
