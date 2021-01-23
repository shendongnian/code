    static void Main(string[] args)
    {
        AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
    
        var implementor = string.Concat(Directory.GetCurrentDirectory(), @"\Implementations\Calculator.dll");
        var implementorBytes = File.ReadAllBytes(implementor);
    
        AppDomain.CurrentDomain.Load(implementorBytes);
    
        Console.WriteLine(GetObject<IAdd>().SumNew(2, 2));
        Console.WriteLine(GetObject<IAdd>().SumNew(2, 5));
    }
    
    static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        var dependencyResolverBaseDirectory = string.Concat(Directory.GetCurrentDirectory(), @"\Implementations");
    
        return Directory.GetFiles(dependencyResolverBaseDirectory, "*.dll")
            .Select(Assembly.LoadFile)
            .FirstOrDefault(assembly => string.Compare(args.Name, assembly.FullName, StringComparison.CurrentCultureIgnoreCase) == 0);
    }
    
    public static T GetObject<T>()
    {
        var t = typeof(T);
                
        var objects = (
            from assembly in AppDomain.CurrentDomain.GetAssemblies()
            from type in assembly.GetExportedTypes()
            where typeof(T).IsAssignableFrom(type) && (string.Compare(type.FullName, t.FullName, StringComparison.CurrentCultureIgnoreCase) != 0)
            select (T)Activator.CreateInstance(type)
        ).ToList();
    
        return objects.FirstOrDefault();
    }
