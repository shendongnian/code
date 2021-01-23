    class A
    {
      public virtual void M1();
      public void M2();
    }
    
    class B : A
    {
      public override sealed void M1();
    }
    sealed class C : A
    {
       //other stuff	
    }
    class D : A
    {
       public new void M2(); //marking A as sealed would prevent this 
    }
