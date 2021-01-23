    public class A4 : A3, ICloneable<A4>
    {
        public int X4 { get; set; }
        public A4(int x1, int x2, int x3, int x4)
            : base(x1, x2, x3)
        {
            this.X4 = x4;
        }
        public override A3 Clone()
        {
            return ((ICloneable<A4>)this).Clone();
        }
        A4 ICloneable<A4>.Clone()
        {
            return new A4(X1, X2, X3, X4);
        }
    }
