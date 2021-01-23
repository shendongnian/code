    [ContractClassFor(typeof(IAsyncCacheProvider))] // note this small change here!
    sealed class AsyncCacheProviderContract : IAsyncCacheProvider
    {
        public Task<bool> GetAsync<T>(string key, out T value)
        {
            Contract.Requires(!String.IsNullOrEmpty(key));
            throw new NotSupportedException(); // makes the compiler happy enough
        }
    }
