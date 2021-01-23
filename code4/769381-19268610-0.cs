    asana.GetMe(o =>
    {
        var user = o as AsanaUser;
        Console.WriteLine("Hello, " + user.Name);
    }).Wait();   <---------------
