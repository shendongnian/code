    public static class TransactionLogExtensions {
        public static IQueryable<TransactionLog> OnlyDividends(this IQueryable<TransactionLog> tl)
        {
            return tl.Where(t=>t.SourceTypeID == (int)JobType.Dividend || t.SourceTypeID == (int)JobType.DividendAcct);
        }
    }
