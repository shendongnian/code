    public static class SqlHelpers
    {
        public static IEnumerable<T> ExecuteAdhocQuery<T>(SqlConnection con, string sql, CommandType cmdType, Func<SqlDataReader, T> converter, params SqlParameter[] args)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, con) { CommandType = cmdType })
                {
                    cmd.Parameters.AddRange(args);
                    if (con.State != ConnectionState.Open) { con.Open(); }
                    var ret = new List<T>();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            ret.Add(converter.Invoke(rdr));
                        }
                    }
                    return ret;
                }
            }
            catch (Exception e)
            {
                // log error?
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                throw e; // handle exception...
            }
        }
               
        public void Test()
        {
            using (SqlConnection con = new SqlConnection("connection string here"))
            {
                var data = ExecuteAdhocQuery(con,
                    "SELECT ID, Name FROM tblMyTable WHERE ID = @Id and Status = @Status;",
                    CommandType.Text, (x) => new { Id = x.GetInt32(0), Name = x.GetString(1) },
                    new SqlParameter("@Id", SqlDbType.Int) { Value = 1 },
                    new SqlParameter("@Status", SqlDbType.Bit) { Value = true });
                Console.WriteLine(data.Count());
            }
        }
    }
