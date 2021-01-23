    interface ITestClass<out T>
    {
        T get();
    }
    class Test<T> : ITestClass<T> where T : ITest
    {
        public T get()
        {
            return default(T);
        }
    }
    ITestClass<ITest> s = new Test<Timpl>(); // Does compile
