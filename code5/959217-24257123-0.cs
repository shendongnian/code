    Assembly assembly = Assembly.GetAssembly(typeAssembly);
    //get the type
    Type classType = assembly.GetType(typeName);
    //using a static property
    var instance = YourApp.Unity.Resolve(classType);
