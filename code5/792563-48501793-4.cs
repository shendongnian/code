    public class All : IMonoid<bool>
    {
        public static All Instance = new All();
        private All() { }
        public bool Combine(bool x, bool y)
        {
            return x && y;
        }
        public bool Identity
        {
            get { return true; }
        }
    }
