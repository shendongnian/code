    public class Derp
    {
        class Test<T> : TestUtil.ITest<T, T>
        {
            public string Name(T[] input, T[] iters) 
            {
                return "asdf";
            }
            public void Run(T[] input, T[] iters)
            {
                 run(input, iters);
            }
            public void Dispose() {}
        }
    
        public TestUtil.ITest<T, T> Foo<T>(T x)
        {
             //stuff
             return new Test<T>();
        }
    }
