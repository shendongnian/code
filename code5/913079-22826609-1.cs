    static void Main(string[] args)
    {
        AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
    
        var implementor = string.Concat(Directory.GetCurrentDirectory(), @"\Implementations\Calculator.dll");
        var implementorBytes = File.ReadAllBytes(implementor);
    
        AppDomain.CurrentDomain.Load(implementorBytes);
    
        Console.WriteLine(GetObject<IAdd>().SumNew(2, 2));
    }
    
    static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        var dependencyResolverBaseDirectory = string.Concat(Directory.GetCurrentDirectory(), @"\Implementations");
    
        foreach (var file in Directory.GetFiles(dependencyResolverBaseDirectory, "*.dll"))
        {
            var assembly = Assembly.LoadFile(file);
    
            if (string.Compare(args.Name, assembly.FullName, StringComparison.CurrentCultureIgnoreCase) == 0)
            {
                return assembly;
            }
        }
    
        return null;
    }
    
    public static T GetObject<T>()
    {
        var t = typeof(T);
                
        var objects = (
            from assembly in AppDomain.CurrentDomain.GetAssemblies()
            from type in assembly.GetExportedTypes()
            where typeof(T).IsAssignableFrom(type) && !type.FullName.Equals(t.FullName)
            select (T)Activator.CreateInstance(type)
        ).ToArray();
    
        return objects.FirstOrDefault();
    }
