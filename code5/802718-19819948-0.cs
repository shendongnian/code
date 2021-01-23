        public static Dictionary<string, object> cache
            = new Dictionary<string, object>();
        public static string ToString<T>(
                Expression<Func<T, string>> expression,
                T input)
        {
            string key = typeof(T).FullName + ":" + expression.ToString();
            object o;  cache.TryGetValue(key, out o);
            Func<T, string> method = (Func<T, string>)o;
            if (method == null)
            {
                method = expression.Compile();
                cache[key] = method;
            }
            return method.Invoke(input);
        }
