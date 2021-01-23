    public class Exceptions
    {
       public override bool Equals(object o)
       {
          return this.Equals(o as Exceptions);
       }
    
       public bool Equals(Exceptions ex)
       {
           if(ex == null)
              return false;
           else
           {
               // Do comparison here
           }
       }
    }
