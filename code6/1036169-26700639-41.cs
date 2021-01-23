    public static class Decision
    {
        public static Decision<I,I> Ask<I>()
        {
            return input => DecisionResult.Return(input);
        }
    }
