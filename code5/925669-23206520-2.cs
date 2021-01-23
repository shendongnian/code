    class SomeFactoryClass
    {
       public SomeBaseClass CreateObject() { return new SomeClass(); }
    }
    SomeBaseClass var3 = SomeFactoryClass.CreateObject();
