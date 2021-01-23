    private static readonly AppDomain OriginalAppDomain;
    // Here, "Program" is my first class constructor called on startup.
    static Program()
    {
        AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += CurrentDomain_AssemblyResolve;
        // Second app domain for old DLLs.
        OriginalAppDomain = AppDomain.CreateDomain("Original DLLs", new Evidence());
        OriginalAppDomain.AssemblyResolve += CurrentDomain_AssemblyResolve_Original;
        OriginalAppDomain.ReflectionOnlyAssemblyResolve += CurrentDomain_AssemblyResolve_Original;
    }
