    interface IKey1 { int ID { ... } }
    interface IKey2 { int ID { ... } }
    class MyOwnerClass : IKey1, IKey2
    {
      IKey1.ID  {  ....  }
      IKey2.ID  {  ....  }
    
      // the only way to access this:
      void Foo() { int i = ((IKey1)this).Id; }
    }
