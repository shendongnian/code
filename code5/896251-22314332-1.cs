    public class A1 : ICloneable
    {
        public A1(int x1) { this.X1 = x1; }
        protected A1(A1 copy) { this.X1 = copy.X1; }
        
        public int X1 { get; set; }
    
        public virtual object Clone()
        {
            return new A1(this); // Protected copy constructor
        }
    }
