    public static class Function
    {
        public static Func<TIn, TOut> Constant<TIn, TOut>(TOut result)
        {
            return x => result;
        }
        public static Func<TIn, TOut> Select<TIn, TMid, TOut>(
            this Func<TIn, TMid> func,
            Func<TMid, TOut> proj)
        {
            return x => proj(func(x));
        }
        public static Func<TIn, TOut> SelectMany<TIn, TMid, TOut>(
            this Func<TIn, TMid> func,
            Func<TMid, Func<TIn, TOut>> proj)
        {
            return x => proj(func(x))(x);
        }
        public static Func<TIn, TOut> SelectMany<TIn, TMid1, TMid2, TOut>(
            this Func<TIn, TMid1> func,
            Func<TMid1, Func<TIn, TMid2>> proj1,
            Func<TMid1, TMid2, TOut> proj2)
        {
            return x => {
                var mid1 = func(x);
                var mid2 = proj1(mid1)(x);
                return proj2(mid1, mid2);
            };
        }
    }
