        public static Dictionary<string, SqlParameter> GetParamsFromInputString(string inputString)
        {
            var output = new Dictionary<string, SqlParameter>();
            // use Regex to translate the input string (something like "[CookingTime] < 30 and [Cost] < 20" ) into a key value pair
            // and then build sql parameter and return out
            // The key will be the database field while the corresponding value is the sql param with value
            return output;
        }
        public void TestWithInput(string condition)
        {
            var parameters = GetParamsFromInputString(condition);
            
            // first build up the sql query:
            var sql = "SELECT Id, Name from tblMyTable WHERE " + parameters.Select(m => string.Format("{0}={1}", m.Key, m.Value.ParameterName)).Aggregate((m,n) => m + " AND " + n);
            using (SqlConnection con = new SqlConnection("connection string here"))
            {
                var data = ExecuteAdhocQuery(con,
                    sql,
                    CommandType.Text,
                    (x) => new { Id = x.GetInt32(0), Name = x.GetString(1) },
                    parameters.Select(m => m.Value).ToArray());
            }
        }
