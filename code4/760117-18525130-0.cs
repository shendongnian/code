    public static class SqlHelpers
    {
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
        public static IEnumerable<SqlParameter> GetParamsFromInputString(string inputString)
        {
            var output = new List<SqlParameter>();
            // use Regex to translate the input string (something like "[CookingTime] < 30 and [Cost] < 20" ) into a key value pair
            // and then build sql parameter and return out
            // output.Add()
            return output;
        }
        public static IEnumerable<T> ExecuteAdhocQuery<T>(SqlConnection con, string sql, CommandType cmdType, Func<SqlDataReader, T> converter, params SqlParameter[] args)
        {
            try
            {
                using(SqlCommand cmd = new SqlCommand(sql, con))
                {
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
    }
