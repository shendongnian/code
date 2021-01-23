    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.Error.WriteLine("Expected arguments: <Assembly-Path> <New-Assembly-Path>");
            Environment.Exit(1);
        }
    
        var assemblyPath = args[0];
        var newAssemblyPath = args[1];
        var assemblyDef = AssemblyDefinition.ReadAssembly(assemblyPath);
    
        Console.WriteLine("Loaded assembly " + assemblyDef);
    
        assemblyDef.Name.Name = "New Name";
        assemblyDef.MainModule.Name = "new Name";
        assemblyDef.Name.Version = new Version(1, 0, 0, 0);
    
        var resources = assemblyDef.MainModule.Resources;
    
        var att = assemblyDef.CustomAttributes.FirstOrDefault(x => x.AttributeType.Name == "AssemblyFileVersionAttribute");
        att.ConstructorArguments.Clear();
        att.ConstructorArguments.Add(new CustomAttributeArgument(new TypeReference("System", "string", null, null), "1.0.0.0"));
    
        assemblyDef.Write(newAssemblyPath);
    }
