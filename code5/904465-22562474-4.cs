    builder.RegisterGenericFunc(
        typeof(Func<,>).MakeGenericType(typeof(string), typeof(IQuery<>)),
        typeof(Bootstrapper).GetMethod("QueryFuncFactory"));
    public static Func<string, IQuery<T>> QueryFuncFactory<T>(IComponentContext c) {
        return ctx => new Query(c.ResolveNamed<IDbContext>(ctx)));
    }
