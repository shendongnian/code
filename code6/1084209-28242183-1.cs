    Type magicType = typeof (MyClass);
    MyClass c1 = new MyClass("1st class");
    MyClass c2 = new MyClass("2nd class");
    // Get the ItsMagic method and invoke with a parameter value of 100
    MethodInfo magicMethod = magicType.GetMethod("Foo");
    object magicValue = magicMethod.Invoke(c1, null);   // Output is 1st class
