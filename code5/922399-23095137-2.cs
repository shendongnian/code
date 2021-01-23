    var innerDomain = AppDomain.CreateDomain("InnerDomain");
    try
    {
        //Subscribe to the events you are interested in    	
    	innerDomain.UnhandledException += innerDomain_UnhandledException;
        innerDomain.FirstChanceException += innerDomain_FirstChanceException;
        
        //Execute your assembly within the app domain
    	innerDomain.ExecuteAssembly("MyInnerProcess.exe");
    }
    catch (Exception ex)
    {
    	//Handle exceptions when attempting to launch the process itself.
    }
    void innerDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
    	//Do something with the unhandled exceptions
    }
    void innerDomain_FirstChanceException(object sender, FirstChanceExceptionEventArgs e)
    {
    	//Do something with the first chance exceptions
    }
