    public interface ICache { ... }
    public class Cache<T> : ICache { ... }
    public boolean doSth(ICache cache, CacheItem item){
        ...
    }
