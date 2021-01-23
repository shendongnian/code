    var assembly = Assembly.LoadFile(@"C:\TestLibrary.dll");
    var type = assembly.GetType("TestLibrary.Class1");
    dynamic test = Activator.CreateInstance(type);
    foreach(dynamic user in test.user)
        Console.WriteLine("User: {0}, Age: {1}", user.name, user.age);
