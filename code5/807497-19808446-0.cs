    private class A
    {
        public ICachePolicy<A> CachePolicy { get; private set; }
        public A(ICachePolicy<A> cachePolicy)
        {
            CachePolicy = cachePolicy;
        }
    }
    private class B
    {
        public ICachePolicy<B> CachePolicy { get; private set; }
        public B(ICachePolicy<B> cachePolicy)
        {
            CachePolicy = cachePolicy;
        }
    }
    private interface ICachePolicy<T> { }
    private class CachePolicy<T> : ICachePolicy<T> { }
