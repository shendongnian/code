    public class A
    {
      public int AID { get; set; }
      public somePrimitive AdditionalPropertyOfA { get; set; }
      public somePrimitive AnotherPropertyOfA { get; set; }
      public virtual ICollection<B> MyBs { get; set; }
    }
    public class B
    {
      public int BID { get; set; }
      public int AID { get; set; }      
      public virtual ICollection<C> MyCs { get; set; }
    }
    public class C
    {
      public int CID { get; set; }
      public int BID { get; set; }      
    }
