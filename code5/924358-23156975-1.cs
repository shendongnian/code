    public static class Extensions
    {
        public static bool TryParse<T>(this string source, out T result)
            where T : struct
        {
            result = default(T);
            var method = typeof (T)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .FirstOrDefault(x => x.Name == "TryParse" && x.GetParameters()
                .Any(p => p.ParameterType.IsAssignableFrom(typeof(string))));
            if(method == null) return false;
            bool isValid =  (bool)method
                .Invoke(null, new object[] {source, result});
            if (isValid) return true;
            return false;
        }
    }
