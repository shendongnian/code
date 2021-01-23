    var t1 = typeof(double);
    Console.WriteLine(t1);        // "System.Double"
    var t2 = t1.MakeByRefType();
    Console.WriteLine(t2);        // "System.Double&"
    var t3 = t2.GetElementType();
    Console.WriteLine(t3);        // "System.Double"
    Console.WriteLine(t1 == t3);  // "True"
