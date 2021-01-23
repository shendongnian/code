    //in your startup method
    AppDomain currentDomain = AppDomain.CurrentDomain;
    currentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);
    
    //...
    private static Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
    {
        //not sure if this will be what the name is, you'd have to play with it
        if (args.Name == "EntLibContrib.Data.OdpNet.OracleDatabase")
        {
            return typeof(EntLibContrib.Data.OdpNet.OracleDataReaderWrapper).Assembly;
        }
        //not sure if this is best practice or not (to return null if truly unknown)
        return null;
    }
