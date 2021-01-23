    public static class DecisionResult
    {
        public static DecisionResult<O> Nothing<O>() =>
            new DecisionResult<O>(false);
        public static DecisionResult<O> Return<O>(O value)
            new DecisionResult<O>(true,value);
    }
