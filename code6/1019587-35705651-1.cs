    private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        AppDomain domain = (AppDomain)sender;
        foreach (Assembly asm in domain.GetAssemblies())
        {
            if (asm.FullName == args.Name)
            {
                return asm;
            }
        }
        throw new ApplicationException($"Can't find assembly {args.Name}");
    }
