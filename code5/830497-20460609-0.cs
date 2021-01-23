    class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "launch")
            {
                AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
                AppDomain.CurrentDomain.ExecuteAssemblyByName("TestConsoleApp", "some", "args", DateTime.Now.ToString());
            }
            else
            {
                RunNormally();
            }
        }
        private static void RunNormally()
        {
            string fileName = Process.GetCurrentProcess().MainModule.FileName;
            fileName = fileName.Replace(".vshost", ""); // hack -- if launched in the debugger must remove this.
            Process.Start(fileName, "launch");
            // do other stuff
        }
        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var asmName = new AssemblyName(args.Name);
            var resourceName = Assembly.GetExecutingAssembly().GetManifestResourceNames().FirstOrDefault(r => r.Contains(asmName.Name));
            if (resourceName != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName).CopyTo(memoryStream);
                    return Assembly.Load(memoryStream.GetBuffer());
                }
            }
            return null;
        }
    }
