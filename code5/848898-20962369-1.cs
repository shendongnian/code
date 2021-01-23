    // Option 1
    Base a = new Base();
    Console.WriteLine(a.i);
    // Output using virtual/override --> 0
    // Output using new --> 0
    // Option 2
    Base b = new Derived();
    Console.WriteLine(b.i);
    // Output using virtual/override --> 1
    // Output using new --> 0
    // Option 3
    Derived c = new Derived();
    Console.WriteLine(c.i);
    // Output using virtual/override --> 1
    // Output using new --> 1
    // Option 2
    // Derived d = new Base();
    // Console.WriteLine(d.i);
    // This won't obviously compile
