    public interface IClearBeforeSessionStore
    {
      public void ClearWhichAreBigger();
    } 
    
    public class A : IClearBeforeSessionStore
    {
      public DataTable dt {get;set;}
      public string AnyString { get;set;}
    
      public void ClearWhichAreBigger()
      {
         this.dt = null;
      }
    }
