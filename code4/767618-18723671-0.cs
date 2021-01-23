    class Program
    {
        static void Main(string[] args)
        {
            IWillStackOverflow(0);
        }
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        static int IWillStackOverflow(int i)
        {
            return IWillStackOverflow(i + 1);
        }
    }
