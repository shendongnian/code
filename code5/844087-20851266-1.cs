    public static class DelegateCache
    {
        private static readonly Dictionary<object, Dictionary<string, Delegate>> Cache = new Dictionary<object, Dictionary<string, Delegate>>();
        private static Dictionary<string, Delegate> GetObjectCache(object instance)
        {
            Dictionary<string, Delegate> delegates;
            if (!Cache.TryGetValue(instance, out delegates))
            {
                Cache[instance] = delegates = new Dictionary<string, Delegate>();
            }
            return delegates;
        }
        public static T GetDelegate<T>(object instance, string method)
            where T: class
        {
            var delegates = GetObjectCache(instance);
            Delegate del;
            if (!delegates.TryGetValue(method, out del))
            {
                delegates[method] = del = Delegate.CreateDelegate(typeof(T), instance, method);
            }
            return del as T;
        }
    }
