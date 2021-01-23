    public class MsSqlMyConnection : IMyConnection
    {
        public TModel Query<TModel>(string sql, object parms)
        {
            using (SqlConnection c = new SqlConnection(connString))
            {
                return c.Query<TModel>(sql, parms);
            }
        }
        public int Execute(string sql, object parms)
        {
            using (SqlConnection c = new SqlConnection(connString))
            {
                return c.Execute(sql, parms);
            }
        }
    }
