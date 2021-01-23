    public static class Function
    {
        public static IFunction<TIn, TOut> Create<TIn, TOut>(Func<TIn, TOut> func)
        {
            return new Function<TIn, TOut>(func);
        }
        public static IFunction<TIn, TOut> Constant<TIn, TOut>(TOut result)
        {
            return Create<TIn, TOut>(x => result);
        }
        public static IFunction<TIn, TOut> Select<TIn, TMid, TOut>(
            this IFunction<TIn, TMid> func,
            Func<TMid, TOut> proj)
        {
            return Create(x => proj(func.Apply(x)));
        }
        public static IFunction<TIn, TOut> SelectMany<TIn, TMid, TOut>(
            this IFunction<TIn, TMid> func,
            Func<TMid, IFunction<TIn,TOut>> proj) 
        {
            return Create(x => proj(func.Apply(x)).Apply(x));
        }
        public static IFunction<TIn, TOut> SelectMany<TIn, TMid1, TMid2, TOut>(
            this IFunction<TIn, TMid1> func,
            Func<TMid1, IFunction<TIn, TMid2>> proj1,
            Func<TMid1, TMid2, TOut> proj2)
        {
            return Create(x => {
                var mid1 = func.Apply(x);
                var mid2 = proj1(mid1).Apply(x);
                return proj2(mid1, mid2);
            });
        }
    }
