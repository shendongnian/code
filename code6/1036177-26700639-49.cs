    public static class Decision
    {
        public static Decision<I,I> Ask<I>() =>
            input => DecisionResult.Return(input);
    }
