    class Program
    {
        const string assemblyFullPath = @"H:\Users\dbc\Documents\Visual Studio 2008\Projects\Question18881659\Question18881659\bin\Debug\Question18881659.dll";
        const string assemblyName = @"Question18881659, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
        static Program()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new AssemblyResolver(assemblyName, assemblyFullPath).AssemblyResolve;
        }
