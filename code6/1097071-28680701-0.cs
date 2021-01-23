    public class Base
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public virtual bool ShouldSerializeParentId()
        {
            return false;
        }
    }
    
    public class Derived : Base 
    { 
        public override bool ShouldSerializeParentId()
        {
            return true;
        }
    }
