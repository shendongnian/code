    public static class Decision
    {
        public static Decision<I, O> Either<I, O>( params Decision<I, O>[] decisions )
            input =>
            {
                foreach(var decision in decisions)
                {
                    var res = decision(input);
                    if( res.HasValue )
                    {
                        return res;
                    }
                }
                return DecisionResult.Nothing<O>();
            };
    }
