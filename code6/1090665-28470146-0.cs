    static void Main()
    {
        ServiceBase[] servicesToRun = new ServiceBase[] { new MyService(); };
    #if !DEBUG
        //run the service normally using ServiceBase.Run
        ServiceBase.Run(servicesToRun);
    #else
        //debug the process as a non-service by invoking OnStart and then sleeping
        foreach (ServiceBase s in servicesToRun)
        {
            var serviceType = s.GetType();
            var onStartMethod = serviceType.GetMethod("OnStart", System.Reflection.BindingFlags.Instance | 
                System.Reflection.BindingFlags.NonPublic);
            onStartMethod.Invoke(s, new object[] { new string[0] });
        }
        Debug.WriteLine("done starting services");
        while (true)
            Thread.Sleep(200);
    #endif
    }
