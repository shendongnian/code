    public IList<TResult> GetSqlQuery<TResult>(string sql, params object[] sqlParams)
    {
                    using (TContext con = new TContext())
                    {
                        return Enumerable.ToList(con.Database.SqlQuery<TResult>(sql, sqlParams));
                    }
    }
