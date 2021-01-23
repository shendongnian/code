    static void Main(string[] args)
    {
        var query = new EventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 1 WHERE TargetInstance isa \"Win32_Process\"");
        using (var eventWatcher = new ManagementEventWatcher(query))
        {
            eventWatcher.EventArrived += eventWatcher_EventArrived;
            eventWatcher.Start();
            Console.WriteLine("Started");
            Console.ReadLine();
            eventWatcher.EventArrived -= eventWatcher_EventArrived;
            eventWatcher.Stop();
        }
    }
    static void eventWatcher_EventArrived(object sender, EventArrivedEventArgs e)
    {
        try
        {
            var instanceDescription = e.NewEvent.GetPropertyValue("TargetInstance") as ManagementBaseObject;
            if(instanceDescription!=null)
            {
                var executablePath = instanceDescription.GetPropertyValue("ExecutablePath");
                if(executablePath!=null)
                {
                    Console.WriteLine("Application {0} started", executablePath.ToString());
                }
             }
        }
        catch (ManagementException) { }
    }
