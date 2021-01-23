    public class A
    {
    }
    public class B
    {
        private readonly A _a;
        public B(A a)
        {
            _a = a.ThrowIfDefault(a);
        }
    }
