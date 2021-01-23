    public static String ExecuteSimpleSelectQuery(string ConnectionString, 
                                      string _Query, string DataTableName)
        {      
            SqlConnection conn = new SqlConnection(ConnectionString);            
            SqlCommand cmd = new SqlCommand("yourstoredprocedurename",conn);
            SqlDataAdapter SDA = new SqlDataAdapter();
            DataTable dt = new DataTable(DataTableName);
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SDA.SelectCommand = cmd;
            SDA.Fill(dt);
            conn.Close();
            return dt.Rows[0].ItemArray[0].ToString();
        }
