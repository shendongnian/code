    public static class Extensions
    {
        public static bool TryParse<T>(this string source, out T result)
            where T : struct
        {
            result = default(T);
            var method = typeof (T)
                .GetMethod("TryParse", new [] {typeof (string), typeof (T).MakeByRefType()});
            if(method == null) return false;
            bool isValid =  (bool)method
                .Invoke(null, new object[] {source, result});
            if (isValid) return true;
            return false;
        }
    }
