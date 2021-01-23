    class Test<T> where T : struct, IConvertible
    {
        private static Func<int, T> _getInt;
    
        static Test()
        {
            var param = Expression.Parameter(typeof(int), "x");
            UnaryExpression body = Expression.Convert(param, typeof(T));
            _getInt = Expression.Lambda<Func<int, T>>(body, param).Compile();
        }
    
        public static T TestFunction(T x)
        {
            int n = Convert.ToInt32(x);
            T result = _getInt(n);
            return result;
        }
    }
