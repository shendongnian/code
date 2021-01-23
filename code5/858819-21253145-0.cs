    var appDomain = Thread.GetDomain();
    var assemblyName = new AssemblyName("MyAssembly");
    var assemblyBuilder = appDomain.DefineDynamicAssembly(
      assemblyName,
      AssemblyBuilderAccess.Run
    );
    var moduleBuilder = assemblyBuilder.DefineDynamicModule("MyModule");
    var typeBuilder = moduleBuilder.DefineType(
      "MyException",
      TypeAttributes.Class,
      typeof(Exception)
    );
    var exceptionType = typeBuilder.CreateType();
    var exception = (Exception) Activator.CreateInstance(exceptionType);
    throw exception;
