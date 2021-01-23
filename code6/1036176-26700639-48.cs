    public static class Decision
    {
        public static Decision<I, V> Select<I, U, V>(this Decision<I, U> self, Func<U, V> map) =>
            input =>
            {
                var res = self(input);
                return res.HasValue
                    ? DecisionResult.Return(map(res.Value))
                    : DecisionResult.Nothing<V>();
            };
        public static Decision<I, V> SelectMany<I, T, U, V>(
            this Decision<I, T> self,
            Func<T, Decision<I, U>> select,
            Func<T, U, V> project)
            input =>
            {
                var resT = self(input);
                if (resT.HasValue)
                {
                    var resU = select(resT.Value)(input);
                    return resU.HasValue
                        ? DecisionResult.Return(project(resT.Value, resU.Value))
                        : DecisionResult.Nothing<V>();
                }
                else
                {
                    return DecisionResult.Nothing<V>();
                }
            };
        public static Decision<I, O> Where<I, O>(this Decision<I, O> self, Predicate<O> pred)
            input =>
            {
                var res = self(input);
                return res.HasValue
                    ? pred(res.Value)
                        ? DecisionResult.Return(res.Value)
                        : DecisionResult.Nothing<O>()
                    : DecisionResult.Nothing<O>();
            };
    }
