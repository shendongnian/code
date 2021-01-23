    var assembly = typeof (User).Assembly;
    var typeList = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract 
        && typeof (IEntity).IsAssignableFrom(t));
    MethodInfo testMethodInfo =
        typeof (Helpers.EntityContextHelper)
        .GetMethod("TestRepositoryForEntity").GetGenericMethodDefinition();
    foreach (var type in typeList)
    {
        Console.WriteLine("Checking type {0}", type.FullName);
        //we need an instance;
        object instance = Activator.CreateInstance(type);
        //create the correct generic method:
        var testMethodToCall = testMethodInfo.MakeGenericMethod(type);
        //invoke
        testMethodToCall.Invoke(null, new [] { instance });
    }
