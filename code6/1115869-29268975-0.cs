    protected bool MyMethod (ref IMyInterface model) 
    {
        // This has to be allowed
        model = new SomeOtherMyInterface();
    }
    // Now, in your usage:
    var model = new MyClass(); // Exactly the same as MyClass model = new MyClass();
    
    MyMethod(ref model); // Won't compile...
    // Here, model would be defined as `MyClass` but have been assigned to a `SomeOtherMyInterface`, hence it's invalid...
