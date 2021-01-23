    Assembly assembly = Assembly.GetExecutingAssembly();
    FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
    string version = fvi.FileVersion;
    log4net.GlobalContext.Properties["LogFileName"] = version + "_logfile.txt";
            
    log4net.Config.XmlConfigurator.Configure(…);
