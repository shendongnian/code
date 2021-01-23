    //make sure the extensions namespace is defined where this code is run.
    Console.WriteLine(((ushort)255).GetBytes().ToBase64());
    Console.WriteLine(10.0.GetBytes().ToBase64());
    Console.WriteLine(((int)2000000000).GetBytes().ToBase64());
    Console.WriteLine(((short)128).GetBytes().ToBase64());
    //Below causes an error
    Console.WriteLine("cool".GetBytes().ToBase64()); //because BitConvert.GetBytes has no overload accepting an argument of type string.
