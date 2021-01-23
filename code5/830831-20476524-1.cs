    public static class ResultFactory
    {
        public static Result<T> Create<T>(int total, int page, List<T> items)
        {
            return new Result<T> { Total = total, Page = page, Items = items };
        }
    }
