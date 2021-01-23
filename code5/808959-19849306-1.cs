    using (SomeIDisposableObject someThing = new SomeIDisposableObject())
    {
       // I am next up for being disposed of.
       using (SomeOtherIDisposableObject someOtherThing = new SomeOtherIDisposableObject())
       {
          // I will get disposed of first since I am nested.
       }
    }
