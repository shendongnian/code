    public static void Main(string[] args)
    {
        IEnumerable<WithRoot> collection = Enumerable.Range(0, 10)
           .Where(x => x % 2 != 0)
           .Reverse()
           .Select(x => new WithRoot(x, Math.Sqrt(x)));    
    }
    
    private sealed class WithRoot
    {
        public WithRoot(int orig, double root)
        {
            this.Original = orig;
            this.SquareRoot = root;
        }
    
        public int Original { get; private set; }
    
        public double SquareRoot { get; private set; }
    }
