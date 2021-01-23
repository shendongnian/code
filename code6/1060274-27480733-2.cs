    var jobId = Guid.NewGuid();
    var jobIdBytes = jobId.ToByteArray();
    var pid = Process.GetCurrentProcess().Id;
    var pipeName = "pipe" + pid;
    var running = true;
    new Thread(() =>
    {
        using (var pipeServer = new NamedPipeServerStream(pipeName))
        {
            while (running)
            {
                pipeServer.WaitForConnection();
                pipeServer.Write(jobIdBytes, 0, jobIdBytes.Length);
                pipeServer.Disconnect();
            }
        }
    }).Start();
