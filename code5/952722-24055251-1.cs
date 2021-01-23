    public class A
    {
        private C c = new C();
        static void Main(string[] args)
        {
            c.Dispose();
            c = null;
        }
    }
    public static class B
    {
        private static C c;
		
        public static LastC
        {
            get
            {
                return c;
            }
            set
            {
               c = value;
            }
        }
    }
    public class C : IDisposable
    {		
        public C()
        {
            B.C = this;
        }
        public void Dispose()
        {
            if (B.LastC == this)
            {
                // LastC has not been set by another instance.
                B.LastC = null;
            }
        }
    }
