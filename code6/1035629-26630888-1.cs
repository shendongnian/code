    int integer = 0;
    Console.WriteLine(integer.GetType().IsValueType); //true
    double dbl = 0.0;
    Console.WriteLine(dbl.GetType().IsValueType); //true
    S s = new S();
    Console.WriteLine(s.GetType().IsValueType); //true
    Test t = Test.a;
    Console.WriteLine(t.GetType().IsValueType); //true
