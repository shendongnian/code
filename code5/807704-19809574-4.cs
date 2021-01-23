    var ints = new SafeArray<int>(10);
    var strings = new SafeArray<string>(5);
    var classes = new SafeArray<MyClass>(10);
    ints[0] = 1;
    strings[0] = "test";
    classes[0] = new MyClass();
    Console.WriteLine((int?)ints[10]); // null
    Console.WriteLine((int?)ints[0]); // 1
    Console.WriteLine(strings[0]); // test
    Console.WriteLine(strings[100]); // null
    Console.WriteLine(classes[5]); // null
    Console.WriteLine(classes[0]); // MyNamespace.MyClass
     
