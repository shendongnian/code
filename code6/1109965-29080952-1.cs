    class SingleInstanceAppStarter
    {
    	static SingleInstanceApp app = null;
    
    	public static void Start(Form f, StartupNextInstanceEventHandler handler)
    	{
    		if (app == null && f != null)
    		{
    			app = new SingleInstanceApp(f);
    		}
    		app.StartupNextInstance += handler;
    		app.Run(Environment.GetCommandLineArgs());
    	}
    }
