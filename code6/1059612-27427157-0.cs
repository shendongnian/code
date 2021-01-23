    var one = new TestEventHandler(TestHandler);
    var two = new TestEventHandler(TestHandler);
    var three = new TestEventHandler(one);
    Console.WriteLine(object.ReferenceEquals(one, two));
    Console.WriteLine(one.Equals(two));
    Console.WriteLine(one.Equals(three));
