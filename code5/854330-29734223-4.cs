    public static class Factory
    {
        public static T Clone<T>(this T other) where T : DrawingObject
        {
            return Dynamic<T>.CopyCtor(other);
        }
    }
    public static class Dynamic<T> where T : DrawingObject
    {
        static Dictionary<Type, Func<T, T>> cache = new Dictionary<Type,Func<T,T>>();
        public static T CopyCtor(T other)
        {
            Type t=other.GetType();
            if (!cache.ContainsKey(t))
            {
                var ctor=t.GetConstructor(new Type[] { t });
                cache.Add(t, (x) => ctor.Invoke(new object[] { x }) as T);
            }
            return cache[t](other);
        }
    }
