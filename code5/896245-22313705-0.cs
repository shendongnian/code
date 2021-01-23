    public interface ICloneable<out T>
    {
        T Clone();
    }
    public class A1 : ICloneable<A1>
    {
        public int X1 { get; set; }
        public A1(int x1) { this.X1 = x1; }
        public virtual A1 Clone()
        {
            return new A1(X1);
        }
    }
    public class A2 : A1, ICloneable<A2>
    {
        public int X2 { get; set; }
        public A2(int x1, int x2)
            : base(x1)
        {
            this.X2 = x2;
        }
        public new A2 Clone()
        {
            return new A2(X1, X2);
        }
    }
    public class A3 : A2, ICloneable<A3>
    {
        public int X3 { get; set; }
        public A3(int x1, int x2, int x3)
            : base(x1, x2)
        {
            this.X3 = x3;
        }
        public new A3 Clone()
        {
            return new A3(X1, X2, X3);
        }
    }
