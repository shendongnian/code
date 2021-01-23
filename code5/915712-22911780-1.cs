    public class ServiceOne : IServiceOne
    {
       public Singleton Const
       { 
          get
          {
             return Singleton.Instance;
          }
       }
    }
