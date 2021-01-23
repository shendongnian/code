    public class MyObject
    {
        public int Id {get;set;}
        public overrides bool Equals(object obj)
        {
               if(obj==null)
                   return false;
               return (MyObject)obj).Id.Equals(this.Id)
        }
    }
