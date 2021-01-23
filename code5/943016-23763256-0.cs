        public class SomeDAO
        {
            private readonly string _connectionString;
            public SomeDAO(string dsn)
            {
                _connectionString = dsn;
            }
            public IEnumerable<AssetVO> DoWork()
            {
                const string cmdText = "SELECT [AssetId] FROM [dbo].[Asset]";
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(cmdText, conn))
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return new AssetVO
                            {
                                AssetId = Guid.Parse(dr["AssetId"].ToString()),
                            };
                        }
                    }
                }
            }
        }
