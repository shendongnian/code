    public class NoThreading : IThreads
    {
        public Task<TRet> StartNew<TRet>(Func<TRet> func)
        {
            return Task.FromResult(func());
        }
    }
