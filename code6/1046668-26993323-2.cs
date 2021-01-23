    public class Base 
    {
        protected void Delete(Guid? id)
        { 
            if (id != null)
            {
               //code goes here
               
               //execute hook only if id is not null
               OnDelete(id);
            }
        }
        protected virtual void OnDelete(Guid? guid) {}
    }
    public class Derived : Base
    {
        protected override void OnDelete(Guid? guid)
        {
            //code goes here
        }
    }
