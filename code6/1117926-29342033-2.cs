    var assemblyName = new AssemblyName("MyDynamicAssembly");
    var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
    var moduleBuilder = assemblyBuilder.DefineDynamicModule("Module");
    
    var typeBuilder = moduleBuilder.DefineType("MyNewType", TypeAttributes.Public | TypeAttributes.Class | TypeAttributes, typeof(YourClassBase), new[] { typeof(IYourInterface) } );
