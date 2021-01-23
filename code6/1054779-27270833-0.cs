    static void Main()
    {
        AppDomain.CurrentDomain.AssemblyResolve += FindAssembly;
        ...
    }
