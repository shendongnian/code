    TestClass test1 = new TestClass("foo", false);
    string serial1 = JsonConvert.SerializeObject(test1);
    test1.FooSpecified = true;
    string serial3 = JsonConvert.SerializeObject(test1);
    Console.WriteLine("Test 1: {0}", serial1);
    Console.WriteLine("Test 1: {0}", serial3);
