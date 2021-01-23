    class A {}
    class B : A {}
    // Here we create an instance of B and assign it to a reference of
    // type A (B is a subclass of A so this is correct). This doesn't
    // change the type of B.
    A a = new B();
    Console.WriteLine(a.GetType()) // => prints B
    // You can always assign to Object (doesn't change the type of the instance.
    object o = a;
    Console.WriteLine(o.GetType()) // => prints B
    // And you can cast a reference to a different type, as long as they
    // are compatible.
    B b = (B)a;
    Console.WriteLine(b.GetType()) // => prints B
