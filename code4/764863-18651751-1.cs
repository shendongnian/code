    static void Main()
    {
        // Create an Application Domain:
        System.AppDomain newDomain = System.AppDomain.CreateDomain("NewApplicationDomain");
    
        // Load and execute an assembly:
        newDomain.ExecuteAssembly(@"c:\HelloWorld.exe");
    
        // Unload the application domain:
        System.AppDomain.Unload(newDomain);
    }
