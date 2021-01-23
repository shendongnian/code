        Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            Assembly assembly = null;
            Assembly[] assems = AppDomain.CurrentDomain.GetAssemblies();
            String name;
            if (args.Name.IndexOf(",") > -1)
                name = args.Name.Substring(0, args.Name.IndexOf(","));
            else
                name = args.Name;
            foreach (Assembly assem in assems)
            {
                if (assem.GetName().Name == name)
                {
                    return assem;
                }
            }
            return assembly;
        }
