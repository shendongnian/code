    AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
    private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs e)
    {
        Assembly ass = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "\\Libraries\\" + e.Name.Split(new char[] { ',', ' ' })[0] + ".dll");
        return ass;
    }
