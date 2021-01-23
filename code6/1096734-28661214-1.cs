    public static class PocoSqlExtensions
    {
        public static QueryBuilder<T> PocoSql<T>(this T obj)
        {
            return new QueryBuilder<T>(obj);
        }
    }
