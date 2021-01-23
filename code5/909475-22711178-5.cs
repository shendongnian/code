    var a = new ClassA(1);
    var b = new ClassB2(new Ref<ClassA>(() => a, x => a = x));
    b.Print(); // output 1
    var c = a; // backup old reference
    a = new ClassA(2);
    b.Print(); // output 2
    // b stores old instance of a?
    Console.WriteLine(object.ReferenceEquals(b.ClassA, c)); // output false
    // a stores new instance of a?
    Console.WriteLine(object.ReferenceEquals(b.ClassA, a)); // output true
