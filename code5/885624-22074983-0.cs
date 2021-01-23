    var sb = new StringBuilder();
    Assembly asm = Assembly.GetExecutingAssembly();
    sb.AppendLine("File Version:");
    sb.AppendLine(asm.FullName);
    
    sb.AppendLine("References :");
    AssemblyName[] asmNames = asm.GetReferencedAssemblies();
    foreach (AssemblyName nm in asmNames)
    {
        sb.AppendLine(nm.FullName);
    }
    // use sb.ToString() to print out wherever you need to
