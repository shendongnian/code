    String[] names = new String[] {"a", "b", "c"};
    foreach (string name in names) {
    
        Assembly assembly = Assembly.LoadFile("...Assembly.dll");
        Type type = assembly.GetType(name);//name should be the full type name (Namespace.ClassName)
        //here you get your Object instance
        object classInstance = Activator.CreateInstance(type, null);
        MethodInfo Obj= Obj.GetType().GetMethod("getStatus");
        var status = (string)dynMethod.Invoke(Obj, null);
    }
