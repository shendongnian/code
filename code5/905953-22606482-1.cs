    public abstract AbstractDevired: BaseClass
    {
       protected override Foo()
       {
          //put implementation from Derived1 here
       }
    }
    public Derived1: AbstractDevired
    {
      //no need to override here because it is the same logic in AbstractDerived class
    }
    public DerivedClass2: Derived1
    {
       protected override Foo()
       {
          base.Foo();
          //some code here
       }
    }
