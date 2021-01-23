    public class BaseClass
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
    
        protected virtual BasedClass Create()
        {
           return new BaseClass();
        }
    
        public virtual BaseClass SimpleClone()
        {
            var clone = Create(); // The appropriate create will be called
            clone.Value1 = this.Value1;
            clone.Value2 = this.Value2;
            return clone;
        }
    }
    
    public class DerivedClass : BaseClass
    {
        public bool Value3 { get; set; }
    
        public DerivedClass()
        {
            Value3 = true;
        }
    
        protected override BasedClass Create()
        {
           return new DerivedClass();
        }
    
        public override BaseClass SimpleClone()
        {
           var result = base.SimpleClone();
           (result as DerivedClass).Value3 = this.Value3;
        }
    }
