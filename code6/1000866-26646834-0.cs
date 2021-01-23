    public class BaseClass
    {
        public int Id { get; set; }
        public virtual bool ShouldSerializeId()
        {
            return true;
        }
    }
    public class DerivedFromBaseClass : BaseClass
    {
        public override bool ShouldSerializeId()
        {
            return false;
        }
    }
