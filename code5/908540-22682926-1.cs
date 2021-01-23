    public class AAdapter: ITellMyNameInterface
    {
        public AAdapter(A a)
        {
            _a = a;
        }
        public string GetName()
        {
            return _a.GetName();
        }
        private readonly A _a;
    }
    public class BAdapter: ITellMyNameInterface
    {
        public BAdapter(B b)
        {
            _b = b;
        }
        public string GetName()
        {
            return _b.GetName();
        }
        private readonly B _b;
    }
