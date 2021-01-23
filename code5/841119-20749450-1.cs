    BaseClass baseClass = new BaseClass();
    BaseClass child1 = new ChildClass1();
    BaseClass child2 = new ChildClass2();
    Console.WriteLine(GetElementName(baseClass)); // empty string
    Console.WriteLine(GetElementName(child1)); // ChildClass1
    Console.WriteLine(GetElementName(child2)); // ChildClass2
    
