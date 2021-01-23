    System.Type t = Type.GetType("System.String");
    Console.WriteLine("Runtime type of `t`:\t{0}", t.GetType().FullName);
    // Prints "Runtime type of `t` is: System.RuntimeType"
    System.String s = "foo";
    Console.WriteLine("Runtime type of `s`:\t{0}", s.GetType().FullName);
    // Prints "Runtime type of `s` is: System.String"
    object o = s;
    Console.WriteLine("Runtime type of `o`:\t{0}", o.GetType().FullName);
    // Prints "Runtime type of `o` is: System.String"
