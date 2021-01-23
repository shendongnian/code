    // Build an assembly ...
    var appDomain = Thread.GetDomain();
    var assemblyName = new AssemblyName("MyAssembly");
    var assemblyBuilder = appDomain.DefineDynamicAssembly(
      assemblyName,
      AssemblyBuilderAccess.Run
    );
    // ... with a module ...
    var moduleBuilder = assemblyBuilder.DefineDynamicModule("MyModule");
    // ... containing a class.
    var typeBuilder = moduleBuilder.DefineType(
      "MyException",
      TypeAttributes.Class,     // A class ...
      typeof(Exception)         // ... deriving from Exception
    );
    var exceptionType = typeBuilder.CreateType();
    // Create and throw exception.
    var exception = (Exception) Activator.CreateInstance(exceptionType);
    throw exception;
