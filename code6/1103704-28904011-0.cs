    AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolve;
    
    private static Assembly AssemblyResolve(object sender, ResolveEventArgs args){
            if (!args.Name.Contains("ILog"))
                return AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName == args.Name);
            else
            {
                var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName.Contains(args.Name));
                if (assembly == null)
                {
                    string rutaAssemblyILog = ConfigurationManager.AppSettings["AssemblyILog"];
                    Assembly.LoadFile(rutaAssemblyILog);
                }
            }
            return AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName.Contains(args.Name));
    }
