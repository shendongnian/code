    public static class Decision
    {
        public static Decision<I, O> Or<I, O>(this Decision<I, O> left, Decision<I, O> right)
        {
            return input =>
            {
                var res = left(input);
                return res.HasValue
                    ? res
                    : right(input);
            };
        }
    }
