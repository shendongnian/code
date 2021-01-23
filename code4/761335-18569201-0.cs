    var setup = new AppDomainSetup
    {
            ApplicationBase = rootAddInsPath,
             ........
    };
    var appDomain = AppDomain.CreateDomain(...)
    
    //I don't must do this here!!!
    appDomain.AssemblyResolve += (sender, args) =>
    {
         ....
    }
    
    var managerType = typeof(AddInLoadManager);
    var manager =(AddInLoadManager)activatedAddIn.AppDomain.CreateInstanceAndUnwrap(managerType.Assembly.FullName, managerType.FullName);
