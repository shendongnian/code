    private Assembly MyResolveEventHandler(object sender, ResolveEventArgs args, Assembly assembly)
        {
            if (assembly.GetName().Name == args.Name)
            {
                return assembly;
            }
            return null;
        }
