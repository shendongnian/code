    public partial class App : Application
    {
        public App()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }
        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var dllName = new AssemblyName(args.Name).Name + ".dll";
            var execAsm = Assembly.GetExecutingAssembly();
            var resourceName = execAsm.GetManifestResourceNames().FirstOrDefault(s => s.EndsWith(dllName));
            if (resourceName == null) return null;
            using (var stream = execAsm.GetManifestResourceStream(resourceName))
            {
                var assbebmlyBytes = new byte[stream.Length];
                stream.Read(assbebmlyBytes, 0, assbebmlyBytes.Length);
                return Assembly.Load(assbebmlyBytes);
            }
    
        }
    }
