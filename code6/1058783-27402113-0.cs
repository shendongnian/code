    public class Base
    {
        protected int prop;
        public virtual int Prop { get { return prop; } }
    }
    
    public class WriteableBase : Base
    {
        public virtual void SetProp(int prop) { this.prop = prop; }
    }
