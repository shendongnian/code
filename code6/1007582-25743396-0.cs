    PipeSecurity ps = new PipeSecurity();
    PipeAccessRule psRule = new PipeAccessRule(@"Everyone", PipeAccessRights.ReadWrite, System.Security.AccessControl.AccessControlType.Allow);
    ps.AddAccessRule(psRule);
    var server = new NamedPipeServerStream("HKBackUpRestorePipe", PipeDirection.InOut, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous, 1, 1, ps);
    server.WaitForConnection();
    
    StreamWriter writer = new StreamWriter(server);
    writer.WriteLine ...
    writer.Flush();
