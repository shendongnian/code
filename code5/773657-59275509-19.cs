    class Program
    {
        const string assemblyFullPath = @"C:\Full-path-to-my-assembly\MyAssembly.dll";
        const string assemblyName = @"MyAssembly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
        static Program()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new AssemblyResolver(assemblyName, assemblyFullPath).AssemblyResolve;
        }
