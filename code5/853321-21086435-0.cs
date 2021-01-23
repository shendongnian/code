     public void InsertToOracle(string value)
            {
                string oradb = "Data Source=ORCL;User Id=user;Password=password;";
    
                using (OracleConnection conn = new OracleConnection(oradb))
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "Insert into Table1(ColumnName) VALUES(@ParameterName)";
                    cmd.Parameters.Add(new OracleParameter("@ParameterName", value));
                    var rowsUpdated = cmd.ExecuteNonQuery();
    
                }
            }
