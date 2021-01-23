    public static class DecisionResult
    {
        public static DecisionResult<O> Nothing<O>()
        {
            return new DecisionResult<O>(false);
        }
        public static DecisionResult<O> Return<O>(O value)
        {
            return new DecisionResult<O>(true,value);
        }
    }
