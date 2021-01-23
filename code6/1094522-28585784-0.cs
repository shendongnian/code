    var targetAsm = Assembly.Load(File.ReadAllBytes("[TargetPath]"));
    foreach(var an in targetAsm.GetReferencedAssemblies())
    {
        Console.WriteLine(an.ToString());   
    }
