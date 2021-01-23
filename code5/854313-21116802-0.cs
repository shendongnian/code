    public CloneableBase : ICloneable
    {
        protected abstract CloneableBase CreateClone();
        
        public virtual object Clone()
        {
            CloneableBase clone = CreateClone();
            clone.MyFirstProperty = this.MyFirstProperty;
            return clone;
        }
        
        public int MyFirstProperty { get; set; }
    }
    
    public class CloneableChild : CloneableBase
    {
        protected override CloneableBase CreateClone()
        {
            return new CloneableChild();
        }
        
        public override object Clone()
        {
            CloneableChild clone = (CloneableChild)base.Clone();
            clone.MySecondProperty = this.MySecondProperty;
            return clone;
        }
        
        public int MySecondProperty { get; set; }
    }
