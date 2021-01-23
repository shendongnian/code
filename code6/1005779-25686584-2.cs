       protected IEnumerable<T> SqlQuery(string sql, params object[] parameters)
        {
            if (String.IsNullOrEmpty(sql))
                throw new ArgumentException("sql is null or empty.", "sql");
            DbSqlQuery<T> q = Context.Set<T>().SqlQuery(sql, parameters);
            return q;
        }
