    public static class EnumToString<T>
    {
        public static readonly Func<T, string> Do;
        static EnumToString()
        {
            Type type = typeof(T);
                
            if (!type.IsEnum)
            {
                throw new ArgumentException();
            }
            Type baseType = type.GetEnumUnderlyingType();
                
            var par1 = Expression.Parameter(typeof(T));
            var cast = Expression.Convert(par1, baseType);
            Expression<Func<object, string>> toString = p => p.ToString();
            var body = (MethodCallExpression)toString.Body;
            var toString2 = Expression.Call(cast, body.Method);
            Do = Expression.Lambda<Func<T, string>>(toString2, par1).Compile();
        }
    }
    public static class EnumToObject<T>
    {
        public static readonly Func<T, object> Do;
        static EnumToObject()
        {
            Type type = typeof(T);
            if (!type.IsEnum)
            {
                throw new ArgumentException();
            }
            Type baseType = type.GetEnumUnderlyingType();
            var par1 = Expression.Parameter(typeof(T));
            var cast1 = Expression.Convert(par1, baseType);
            var cast2 = Expression.Convert(cast1, typeof(object));
            Do = Expression.Lambda<Func<T, object>>(cast2, par1).Compile();
        }
    }
    static void Main()
    {
        string str = EnumToString<MyEnum>.Do(MyEnum.Foo); // "1"
        object obj = EnumToObject<MyEnum>.Do(MyEnum.Foo); // (int)1
    }
