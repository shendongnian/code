    public class DecisionFailedException : Exception
    {
        public DecisionFailedException()
            :
            base("The decision wasn't made, and therefore doesn't have a value.")
        {
        }
    }
