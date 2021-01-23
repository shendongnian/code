    public class ThreadedQuery
    {
        
        public class NamedQuery
        {
            public NamedQuery(string TableName, string SQL)
            {
                this.TableName = TableName;
                this.SQL = SQL;
            }
            public string TableName { get; set; }
            public string SQL { get; set; }
        }
        public static async System.Threading.Tasks.Task<System.Data.DataSet> RunThreadedQuery(string ConnectionString, params NamedQuery[] quries)
        {
            
            System.Data.DataSet dss = new System.Data.DataSet();
            List<System.Threading.Tasks.Task<System.Data.DataTable>> asyncQryList = new List<System.Threading.Tasks.Task<System.Data.DataTable>>();
            foreach (var qq in quries)
                asyncQryList.Add(fetchDataTable(qq, ConnectionString));
            foreach (var tsk in asyncQryList)
            {
                System.Data.DataTable tmp = await tsk.ConfigureAwait(false);
                dss.Tables.Add(tmp);
            }
            return dss;
        }
        private static async System.Threading.Tasks.Task<System.Data.DataTable> fetchDataTable(NamedQuery qry, string ConnectionString)
        {
            // Create a connection, open it and create a command on the connection
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable(qry.TableName);
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    System.Diagnostics.Debug.WriteLine("Connection Opened ... " + qry.TableName);
                    using (SqlCommand command = new SqlCommand(qry.SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            System.Diagnostics.Debug.WriteLine("Query Executed ... " + qry.TableName);
                            dt.Load(reader);
                            System.Diagnostics.Debug.WriteLine(string.Format("Record Count '{0}' ... {1}", dt.Rows.Count, qry.TableName));
                            return dt;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception Raised ... " + qry.TableName);
                System.Diagnostics.Debug.WriteLine(ex.Message);
                
                return new System.Data.DataTable(qry.TableName);
            }
            
        }
    }
