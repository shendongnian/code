    var jobIdBytes = new byte[16];
    foreach (var process in Process.GetProcessesByName("jobProcessName"))
    {
        var pipeName = "pipe" + process.Id;
        using (var clientStream = new NamedPipeClientStream(pipeName))
        {
            clientStream.Connect();
            clientStream.Read(jobIdBytes, 0, jobIdBytes.Length);
        }
            
        var jobId = new Guid(jobIdBytes);
        Console.WriteLine(String.Format("pid: {0}, job_id: {1}", process.Id, jobId));
    }
