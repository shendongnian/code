    public interface ILazyCacheProvider : IAppCache
    {
        /// <summary>
        /// Get data loaded - after allways throw cached result (even when data is older then needed) but very fast!
        /// </summary>
        /// <param name="key"></param>
        /// <param name="getData"></param>
        /// <param name="slidingExpiration"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetOrAddPermanent<T>(string key, Func<T> getData, TimeSpan slidingExpiration);
    }
    /// <summary>
    /// Initialize LazyCache in runtime
    /// </summary>
    public class LazzyCacheProvider: CachingService, ILazyCacheProvider
    {
        private readonly Logger _logger = LogManager.GetLogger("MemCashe");
        private readonly Hashtable _hash = new Hashtable();
        private readonly List<string>  _reloader = new List<string>();
        private readonly ConcurrentDictionary<string, DateTime> _lastLoad = new ConcurrentDictionary<string, DateTime>();  
        T ILazyCacheProvider.GetOrAddPermanent<T>(string dataKey, Func<T> getData, TimeSpan slidingExpiration)
        {
            var currentPrincipal = Thread.CurrentPrincipal;
            if (!ObjectCache.Contains(dataKey) && !_hash.Contains(dataKey))
            {
                _hash[dataKey] = null;
                _logger.Debug($"{dataKey} - first start");
                _lastLoad[dataKey] = DateTime.Now;
                _hash[dataKey] = ((object)GetOrAdd(dataKey, getData, slidingExpiration)).CloneObject();
                _lastLoad[dataKey] = DateTime.Now;
               _logger.Debug($"{dataKey} - first");
            }
            else
            {
                if ((!ObjectCache.Contains(dataKey) || _lastLoad[dataKey].AddMinutes(slidingExpiration.Minutes) < DateTime.Now) && _hash[dataKey] != null)
                    Task.Run(() =>
                    {
                        if (_reloader.Contains(dataKey)) return;
                        lock (_reloader)
                        {
                            if (ObjectCache.Contains(dataKey))
                            {
                                if(_lastLoad[dataKey].AddMinutes(slidingExpiration.Minutes) > DateTime.Now)
                                    return;
                                _lastLoad[dataKey] = DateTime.Now;
                                Remove(dataKey);
                            }
                            _reloader.Add(dataKey);
                            Thread.CurrentPrincipal = currentPrincipal;
                            _logger.Debug($"{dataKey} - reload start");
                            _hash[dataKey] = ((object)GetOrAdd(dataKey, getData, slidingExpiration)).CloneObject();
                            _logger.Debug($"{dataKey} - reload");
                            _reloader.Remove(dataKey);
                        }
                    });
            }
            if (_hash[dataKey] != null) return (T) (_hash[dataKey]);
            _logger.Debug($"{dataKey} - dummy start");
            var data = GetOrAdd(dataKey, getData, slidingExpiration);
            _logger.Debug($"{dataKey} - dummy");
            return (T)((object)data).CloneObject();
        }
    }
