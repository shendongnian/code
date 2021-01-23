    static void Main(string[] args)
    {
        System.Reflection.Assembly newAssembly = System.Reflection.Assembly.LoadFrom("ProcessTarget.exe");
        newAssembly.EntryPoint.Invoke(null, new object[1] { new string[0] });
    }
