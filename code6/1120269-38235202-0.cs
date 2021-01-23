    string assemblyPath = "c:\temp\assmebly.dll";
    #if NET46
                    Assembly assembly = Assembly.LoadFrom(assemblyPath);
    #else
                    AssemblyLoadContext context = AssemblyLoadContext.Default;
                    Assembly assembly = context.LoadFromAssemblyPath(assemblyPath);
    #endif
