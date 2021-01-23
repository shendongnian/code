    public class DecisionResult
    {
        public static DecisionResult<O> Nothing<O>()
        {
            return new DecisionResult<O>();
        }
        public static DecisionResult<O> Return<O>(O value)
        {
            return new DecisionResult<O>(value);
        }
    }
    public class DecisionFailedException : Exception
    {
        public DecisionFailedException()
            :
            base("The decision wasn't made, and therefore doesn't have a value.")
        {
        }
    }
