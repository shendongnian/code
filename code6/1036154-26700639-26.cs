        public static Decision<I, O> Either<I, O>( params Decision<I, O>[] decisions )
        {
            return input =>
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
