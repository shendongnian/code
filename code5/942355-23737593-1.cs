    class NaturalImpl
    {
        public void Method()
        {
            int seed = 0;
            return seed++;
        }
    }
    Func<int> natural = new NaturalImpl().Method;
