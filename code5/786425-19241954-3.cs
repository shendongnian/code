    interface IKey1 { int ID { ... } }
    interface IKey2 { int ID { ... } }
    class MyOwnerClass : IKey1, IKey2  // requires explicit imp
    {
      int IKey1.ID  {  ....  }
      int IKey2.ID  {  ....  }
    
      // the only way to access this:
      void Foo() 
      { 
         int i1 = ((IKey1)this).ID; 
         
         IKey2 ik2 = this;
         int i2 = ik2.ID; 
         int i3 = ID; // error, otherwise: which one
      }
    }
