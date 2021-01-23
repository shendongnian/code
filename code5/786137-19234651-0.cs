    //does not implement INestedInterfaceTest<Derived>
    class Derived : NestedInterfaceTest {}
    class Derived2 : NestedInterfaceTest {}
    Derived d = new Derived();
    // breaks because GateWay<Derived2> cannot be constructed
    d.GetNestedInterface<Derived2>();
