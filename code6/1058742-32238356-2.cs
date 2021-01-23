    var assembly = assemblyDef.AssemblyDefinition;
    var types = assembly.MainModule.Types;
    var myTypesToChange = types.Select(t => t);
    var baseType = AssemblyDefinition.ReadAssembly(@"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll").MainModule.Types.Where(t => t.Name.Contains("MarshalByRefObject")).Select(t => t).First();
    foreach (var myType in myTypesToChange)
    {
        myType.BaseType = mainModule.Import(baseType);
    }
