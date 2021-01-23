    public MyDerivedClass : BaseClass
    {
         public void AnotherMethod()
         {
             // there's no point sealing this guy - it's not virtual
         }
         public override sealed void SomeMethod()
         {
             // If I don't seal this guy, then another class derived from me can override again
         }
    }
