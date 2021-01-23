    public AssemblyName[] GetAssemblyNames()
    {
        return AppDomain.CurrentDomain
                        .GetAssemblies()
                        .Select(asm => asm.GetName()).ToArray();
    }
