    public class Base 
    {
        protected void Delete(Guid? guidId)
        { 
            if (id != null)
            {
              OnDelete(guid);
            }
        }
        protected virtual void OnDelete(Guid? guid) {}
    }
    public class Derived : Base
    {
        protected override void OnDelete(Guid? guid)
        {
        
        }
    }
