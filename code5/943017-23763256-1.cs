        public class SomeDAO : IDisposable
        {
            #region backing store
            private readonly SqlConnection _connection;
            #endregion
            public SomeDAO(string dsn)
            {
                _connection = new SqlConnection(dsn);
            }
            public SqlConnection OpenConnection()
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Open();
                return _connection;
            }
            public void CloseConnection()
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
            }
            public IEnumerable<AssetVO> DoWork()
            {
                const string cmdText = "SELECT [AssetId] FROM [dbo].[Asset]";
                try
                {
                    using (var cmd = new SqlCommand(cmdText, OpenConnection()))
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
                finally
                {
                    CloseConnection();
                }
            }
            #region Implementation of IDisposable
            /// <summary>
            ///   Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            /// <filterpriority>2</filterpriority>
            public void Dispose()
            {
                _connection.Dispose();
            }
            #endregion
        }
