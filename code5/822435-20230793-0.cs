    private void Method1()
    {
        //create new domain
        AppDomain domain = AppDomain.CreateDomain("MyDomain");
        AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        //Do work, including the dll loading, on another domain
        domain.DoCallBack(DoWorkOnAnotherDomain);
        //unload dll
        AppDomain.Unload(domain); 
        //still showing dll below ?????
        Assembly[] aAssemblies = AppDomain.CurrentDomain.GetAssemblies(); 
    }
    private static void DoWorkOnAnotherDomain()
    {
        //load dll into new domain
        AssemblyName assemblyName = new AssemblyName();
        assemblyName.CodeBase = "c:\\mycode.dll";
        Assembly assembly = domain.Load(assemblyName);         
        //do work with dll
        //...
    }
