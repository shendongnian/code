    var mFunc = Sum();
    Console.WriteLine("Calling Sum()(1,1) with Invoke() " + Sum().Invoke(1, 1));
    Console.WriteLine("Calling Sum()(2,2) with Invoke() " + Sum().Invoke(2, 2));
    Console.WriteLine("----------");
    Console.WriteLine("Calling Sum()(1,1)" + Sum()(1, 1));
    Console.WriteLine("Calling Sum()(2,2)" + Sum()(2, 2));
    Console.Read();
