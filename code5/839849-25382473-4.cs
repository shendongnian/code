    public static class ParseMethodFactory<T> where T : struct
    {
        private static Func<string, NumberStyles, T> cachedDelegate = null;
        public static Func<string, NumberStyles, T> GetParseMethod()
        {
            if (cachedDelegate == null)
            {
                Type type = typeof(T);
                MethodInfo parseMethod = type.GetMethod("Parse", new[] { typeof(string), typeof(NumberStyles) });
                if (parseMethod != null)
                {
                    cachedDelegate = (Func<string, NumberStyles, T>)Delegate.CreateDelegate(typeof(Func<string, NumberStyles, T>), parseMethod);
                }
            }
            return cachedDelegate;
        }
    }
