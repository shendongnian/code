    static Assembly embedded_assembly;
    static void Main(string[] argss)
    {
        embedded_assembly = LoadEmbeddedAssembly("empty_vs_project", "embedded-dll.dll");
        AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        netsum thisapp = new netsum();
    }
    static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        if (args.Name == embedded_assembly.FullName)
            return embedded_assembly;
        return null;
    }
    public static Assembly LoadEmbeddedAssembly(string resourceNamespace, string assemblyName)
    {
        var assemblyBytes = GetAssembly(resourceNamespace + "." + assemblyName);
        return AppDomain.CurrentDomain.Load(assemblyBytes);
    }
    public static byte[] GetAssembly(string resourceName)
    {
        using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
        {
            var bytes = new byte[stream.Length];
            stream.Read(bytes, 0, (int)stream.Length);
            return bytes;
        }
    }
