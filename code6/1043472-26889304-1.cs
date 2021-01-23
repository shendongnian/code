    static void Main(string[] args)
    {
        AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
        AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        string aname = "MyAssembly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
        var asm = Assembly.Load(aname);
        Console.ReadKey();
    }
    static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        Console.WriteLine("Resolving " + args.Name);
        return Assembly.LoadFrom(@"C:\path\MyAssembly.6.0.dll");
    }
    static void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
    {
        Console.WriteLine("Loading " + args.LoadedAssembly.FullName);
    }
