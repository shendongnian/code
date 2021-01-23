       private System.Reflection.Assembly CurrentDomain_ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().Where(w => w.FullName == args.Name).FirstOrDefault();
            return assembly;
        }
