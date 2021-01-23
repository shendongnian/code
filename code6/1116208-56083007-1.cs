    public class example
    {
        static ScriptMain()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }
        static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.Contains("WinSCPnet"))
            {
                string path = @"Path to DLL";
                return System.Reflection.Assembly.LoadFile(System.IO.Path.Combine(path, "WinSCPnet.dll"));
            }
            return null;
        }
        public void Main()
        { can now use DLL things in here}
    }
