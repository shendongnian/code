    public static class QueryExtensions
    {
        public static IQueryable<Invoice> WhereMonthAndYear(
            this IQueryable<Invoice> query, DateTime? monthAndYear)
        {
            return query.Where(i => i.StartDate >= monthAndYear); // or whatever
        }
    }
