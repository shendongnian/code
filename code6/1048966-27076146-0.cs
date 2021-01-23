    public static Array CreateArray<T>(int[] dimLengths, T x) {
        var arr = Array.CreateInstance(typeof(T), dimLengths);
        var p = Expression.Parameter(typeof(object), "arr");
        var ind = new Expression[dimLengths.Length];
        for (var i = 0; i < dimLengths.Length; i++) {
            ind[i] = Expression.Constant(0);
        }
        var v = Expression.Variable(arr.GetType(), "cast");
        var block = Expression.Block(
            new[] {v}
        ,   new Expression[] {
                Expression.Assign(v, Expression.Convert(p, arr.GetType()))
            ,   Expression.Assign(Expression.ArrayAccess(v, ind), Expression.Constant(x))
            ,   Expression.Constant(null, typeof(object))
            }
        );
        Expression.Lambda<Func<object, object>>(block, p).Compile()(arr);
        return arr;
    }
