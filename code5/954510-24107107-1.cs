    Derived d = new Derived();
    Console.WriteLine(d.Foo);
    Base b = d;
    Console.WriteLine(b.Foo); //compile error
    Derived d2 = (Derived)b; //or Derived d2 = b as Derived;
    Console.WriteLine(d2.Foo); //valid
