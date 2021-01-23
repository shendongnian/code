    BaseClass.prop1 = "someValue";
    Console.WriteLine(BaseClass.prop1);    // prints "someValue"
    Console.WriteLine(DerivedClass.prop1); // prints "someValue"
    
    DerivedClass.prop1 = "otherValue";
    Console.WriteLine(DerivedClass.prop1); // prints "otherValue"
    Console.WriteLine(BaseClass.prop1);    // prints "otherValue"
