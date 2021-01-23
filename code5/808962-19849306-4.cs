    using (SomeIDisposableObject someThing = new SomeIDisposableObject())
    {
       // I will be disposed of.
    }
    using (SomeOtherIDisposableObject someOtherThing = new SomeOtherIDisposableObject())
    {
       // I will also be disposed of.
    }
