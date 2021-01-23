    public class super
    { 
      public virtual Boolean isSuper()
      {
        return true;
      }
    }
    
    public class sub : super
    { 
      public override Boolean isSuper()
      {
        return false;
      }
    }
