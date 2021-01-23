    public class X
    {
      public string a{get;protected set;}
    
      public X()
      {
        this.a = "foo";
      }
    
      public virtual x()
      {
        return this.a;
      }
    }
    
    public class Y : A
    {
      public Y()
      {
        this.a = "bar";
      }
    }
