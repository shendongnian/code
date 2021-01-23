    static void Main(string[] args)
    {
    	if (args.Length == 0)
    	{
    		// we are running as a service
    		ServiceBase[] ServicesToRun;
    		ServicesToRun = new ServiceBase[] { new MyService() };
    		ServiceBase.Run(ServicesToRun);
    	}
    	else if (args[0].Equals("/debug", StringComparison.OrdinalIgnoreCase))
    	{
    		// run the code inline without it being a service
    		MyService debug = new MyService();
    		// use the debug object here
    	}
