    public class Sum : IMonoid<int>
    {
        public int Combine(int x, int y)
        {
            return x + y;
        }
        public int Identity
        {
            get { return 0; }
        }
    }
