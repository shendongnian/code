    var s = new SomeStruct();
    s.SomeField = 5;
    var y = s;
    y.SomeField = 10;
    Console.WriteLine(s.SomeField); //Prints 5
    Console.WriteLine(y.SomeField); //Prints 10
