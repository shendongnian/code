    private static void Main(string[] args)
    {
        Task.Run(() =>
        {
            using (var session = new TraceEventSession("TplCaptureSession"))
            {
                session.EnableProvider(new Guid("2e5dba47-a3d2-4d16-8ee0-6671ffdcd7b5"),
                                       TraceEventLevel.Always);
                session.Source.Dynamic.AddCallbackForProviderEvent("System.Threading.Tasks
                                                                   .TplEventSource",
                    "TaskExecute/Start", @event =>
                    {
                        Console.WriteLine("Inside Task Started");
                    });
                session.Source.Dynamic.AddCallbackForProviderEvent("System.Threading.Tasks
                                                       .TplEventSource", 
                    "TaskExecute/Stop", @event =>
                    {
                        Console.WriteLine("Inside Task Stopped");
                    });
                session.Source.Process();
            }
        });
        var task = Task.Run(async () =>
        {
            await Task.Delay(20000);
        });
        task.Wait();
    }
