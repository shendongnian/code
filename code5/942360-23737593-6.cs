    class NaturalImpl
    {
        public int seed;
        public int Method()
        {
            return seed++;
        }
    }
    Func<int> natural = new NaturalImpl().Method;
