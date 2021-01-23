    var mFunc = Sum();
    Console.WriteLine("Calling mFunc(1,1) with Invoke() " + mFunc.Invoke(1, 1));
    Console.WriteLine("Calling mFunc(2,2) with Invoke() " + mFunc.Invoke(2, 2));
    Console.WriteLine("----------");
    Console.WriteLine("Calling mFunc(1,1)" + mFunc(1, 1));
    Console.WriteLine("Calling mFunc(2,2)" + mFunc(2, 2));
    Console.Read();
