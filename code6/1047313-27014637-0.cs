    public abstract class Base
    {
       public int val {get;set;}
       public bool merge(Base obj) { 
         if(obj.GetType() != this.GetType())
           return false;
         this.val += obj.val;
       }
    }
