    public class DerivedClass : BaseClass
    {
      public int DerivedClassInt { get; set; }
      public DerivedClass (allbaseargs, int pDerivedClassInt)
        : base(allbaseargs)
      {
        DerivedClassInt = pDerivedClassInt;
      }
    }
