    public class BootStrapper
    {
        public BootStrapper()
        {
            var builder = new ContainerBuilder();
    
            Assembly[] assemblies =
                GetAssembliesFromApplicationBaseDirectory(
                    x => x.FullName.StartsWith("Fle.SQLServer"));
    
            builder.RegisterAssemblyTypes(assemblies)
                   .AsImplementedInterfaces();
    
            builder.RegisterAssemblyModules(assemblies);
        }
        private static Assembly[] GetAssembliesFromApplicationBaseDirectory(Func<AssemblyName, bool> condition)
        {
            string baseDirectoryPath =
                AppDomain.CurrentDomain.BaseDirectory;
    
            Func<string, bool> isAssembly =
                file => string.Equals(
                    Path.GetExtension(file), ".dll", StringComparison.OrdinalIgnoreCase);
    
            return Directory.GetFiles(baseDirectoryPath)
                            .Where(isAssembly)
                            .Where(f => condition(new AssemblyName(f)))
                            .Select(Assembly.LoadFrom)
                            .ToArray();
        }
    }
