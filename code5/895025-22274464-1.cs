    public abstract class B // Prevent instantiation
    {
        internal B() {} // Prevent subclassing outside the assembly. 
        public virtual void Dangerous() { ... } 
    }
    public sealed class D : B 
    { 
      public override void Dangerous() 
      { 
        if (!Allowed()) throw whatever;
        base.Dangerous();
      }
