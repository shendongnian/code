    public static class extension
    {
        public static bool IsInWeddingList(this IEnumerable<Wedding> weds, DateTime check)
        {
           return weds.Any(wedding => wedding.When == check);
        }
    }
