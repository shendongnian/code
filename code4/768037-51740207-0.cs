        private static Assembly CurrentDomainAssemblyResolve(object sender, ResolveEventArgs args)
        {
            AssemblyName assyName = new AssemblyName(args.Name);
            string filename = args.Name.ToLower().Split(',')[0];
            string path = "c:\some path or other\"
            string assembly = System.IO.Path.Combine(path, filename);
            if (!assembly.EndsWith(".dll"))
                assembly += ".dll";
            try
            {
                if (System.IO.File.Exists(assembly))
                    return (Assembly.LoadFrom(assembly));
            }
            catch (Exception error)
            {
                // do whatever
            }
            return (null);
        }
