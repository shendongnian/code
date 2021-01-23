    string s = "foo";
    Console.WriteLine("Runtime type of `s`:\t{0}", s.GetType().FullName);
    // Prints "Runtime type of `s` is: System.String"
    dynamic d = s;
    Console.WriteLine("Runtime type of `d:\t{0}", d.GetType().FullName);
    // Also prints "Runtime type of `d` is: System.String"
