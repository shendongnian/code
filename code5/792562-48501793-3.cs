    public class Product : IMonoid<int>
    {
        public int Combine(int x, int y)
        {
            return x * y;
        }
        public int Identity
        {
            get { return 1; }
        }
    }
