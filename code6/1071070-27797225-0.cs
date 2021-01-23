    class Program
    {
        static void Main(string[] args)
        {
            C c = new C();
            c.As.add(1, 2);
        }
    }
    public interface A
    {
        int add(int x, int y);
        int mul(int x, int y);
    }
    public interface B
    {
        int add(int x, int y);
        int mul(int x, int y);
    }
    public class C : A, B
    {
        // Methods from the A-interface.
        public A As { get { return (A)this; } }
        // Methods from the B-interface.
        public B Bs { get { return (B)this; } }
        int A.add(int x, int y)
        {
            return x + y;
        }
        int A.mul(int x, int y)
        {
            return 0;
        }
        int B.add(int x, int y)
        {
            return x;
        }
        int B.mul(int x, int y)
        {
            return y;
        }
    }
    public class D : C
    {
        public D()
        {
            base.As.add(1, 2);
            base.Bs.add(3, 4);
        }
    }
