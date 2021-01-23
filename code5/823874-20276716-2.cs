        var service = new MyTestThing.MyService.WebService1();
        object test1 = service.Method(new object[] { "hello", 3 });
        Console.WriteLine(test1.ToString());
        object test2 = service.Method(new object[] { "hello", "there" });
        Console.WriteLine(test2.ToString());
