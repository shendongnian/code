    public static class ApplicationHost
    {
        private static Dictionary<string, Assembly> _references;
        [STAThread]
        private static void Main()
        {
            _references = new Dictionary<string, Assembly>();
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) => _references.ContainsKey(args.Name) ? _references[args.Name] : null;
            RegisterCurrentAssemblyAndEmbeddedDependencies();
            // continue application bootstrapping...
        }
        public static void RegisterCurrentAssemblyAndEmbeddedDependencies()
        {
            var assembly = Assembly.GetCallingAssembly();
            _references[assembly.FullName] = assembly;
            foreach (var resourceName in assembly.GetManifestResourceNames())
            {
                using (var resourceStream = assembly.GetManifestResourceStream(resourceName))
                {
                    var rawAssembly = new byte[resourceStream.Length];
                    resourceStream.Read(rawAssembly, 0, rawAssembly.Length);
                    var reference = Assembly.Load(rawAssembly);
                    _references[reference.FullName] = reference;
                }
            }
        }
    }
