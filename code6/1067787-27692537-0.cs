            public static void RunWithOpenSqlConnection(string connectionString, Action<SqlConnection> connectionCallBack)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                //Log Error Here
            }
            finally
            {
                if (conn != null)
                    conn.Dispose(); //will close the connection
            }
        }
        public static void ExecuteSqlDataReader(string connectionString, string sqlCommand, Action<SqlDataReader> readerCallBack)
        {
            RunWithOpenSqlConnection(connectionString, delegate(SqlConnection conn)
            {
                SqlCommand cmd = null;
                SqlDataReader reader = null;
                try
                {
                    cmd = new SqlCommand(sqlCommand, conn);
                    reader = cmd.ExecuteReader();
                    readerCallBack(reader);
                }
                catch (Exception ex)
                {
                    //Log Error Here
                }
                finally
                {
                    if (reader != null)
                        reader.Dispose();
                    if (cmd != null)
                        cmd.Dispose();
                }
            });
        }
    //Example calling these
                ExecuteSqlDataReader(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString, "Select EmployeeID FROM Employees;", delegate(SqlDataReader reader)
            {
                List<string> employeeIds = new List<string>();
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        employeeIds.Add((string)reader[0]);
                    }
                }
            });
