    private static IDictionary<Type,object> MultByType = new Dictionary<Type,object>();
    public static T Multiply<T>(T a, int b) {
        Func<T,int,T> mult;
        object tmp;
        if (!MultByType.TryGetValue(typeof (T), out tmp)) {
            var lhs = Expression.Parameter(typeof(T));
            var rhs = Expression.Parameter(typeof(int));
            mult = (Func<T,int,T>) Expression.Lambda(
                Expression.Multiply(lhs, Expression.Convert(rhs, typeof(T)))
            ,   lhs
            ,   rhs
            ).Compile();
            MultByType.Add(typeof(T), mult);
        } else {
            mult = (Func<T,int,T>)tmp;
        }
        return mult(a, b);
    }
