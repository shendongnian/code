    public class B1 : A1, ICloneable
    {
        public B1(int x1, int y1) : base(x1) { this.Y1 = y1; }
        protected B1(B1 copy) : base(copy) { this.Y1 = copy.Y1; }
        
        public int Y1 { get; set; }
    
        public virtual object Clone()
        {
            return new B1(this); // Protected copy constructor
        }
    }
