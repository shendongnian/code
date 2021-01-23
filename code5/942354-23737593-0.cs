    class NaturalImpl
    {
        public int seed;
        public void Method()
        {
            return seed++;
        }
    }
    Func<int> natural = new NaturalImpl().Method;
