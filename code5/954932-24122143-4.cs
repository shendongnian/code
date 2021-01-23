    IServiceContract service = new ImplementsServiceContract();
    Assembly assembly = Assembly.LoadFile(@"C:\myDll.dll");
    var type = assembly.GetType("AddInClass");
    IAddIn addIn = (IAddIn)Activator.CreateInstance(type, service);
    addIn.TestMethod();
