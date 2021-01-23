    var assembly = Assembly.GetExecutingAssembly();
    var itestTypes = assembly.GetTypes().Where (t => t.IsClass &&
                                                typeof(ITest).IsAssignableFrom(t));
    foreach (var t in itestTypes)
    {
    	Console.WriteLine (t.ToString());
    	ITest test = (ITest)Activator.CreateInstance(t);
    	test.Run();
    }
