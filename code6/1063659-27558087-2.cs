    Task<double> backing;
    double SomeProperty { get { return backing.Result; } }
    MyClass()       // in constructor
    {
        backing = someService.SomeAsyncMethod(); // Note, no await here!
    }
