    double pi;
    if(ValueTypeHelper.TryParse("3.1415", out pi)) {
        // .. pi = 3.1415
    }
    ...
    static class ValueTypeHelper {
        static IDictionary<Type, Delegate> cache = new Dictionary<Type, Delegate>();
        public static bool TryParse<T>(string valueStr, out T result) {
            Delegate d = null;
            if(!cache.TryGetValue(typeof(T), out d)) {
                var mInfos = typeof(T).GetMember("TryParse", MemberTypes.Method, BindingFlags.Static | BindingFlags.Public);
                if(mInfos.Length > 0) {
                    var s = Expression.Parameter(typeof(string));
                    var r = Expression.Parameter(typeof(T).MakeByRefType());
                    d = Expression.Lambda<TryParseDelegate<T>>(
                        Expression.Call(mInfos[0] as MethodInfo, s, r), s, r).Compile();
                }
                cache.Add(typeof(T), d);
            }
            result = default(T);
            TryParseDelegate<T> tryParse = d as TryParseDelegate<T>;
            return (tryParse != null) && tryParse(valueStr, out result);
        }
        delegate bool TryParseDelegate<T>(string valueStr, out T result);
    }
