    public static class Add<T>
    {
        public static readonly Func<T, T, T> Do;
    
        static Add()
        {
            var par1 = Expression.Parameter(typeof(T));
            var par2 = Expression.Parameter(typeof(T));
    
            var add = Expression.Add(par1, par2);
    
            Do = Expression.Lambda<Func<T, T, T>>(add, par1, par2).Compile();
        }
    }
    
    public static class Math<T>
    {
        public static T Add(T a1, T a2)
        {
            return Add<T>.Do(a1, a2);
        }
