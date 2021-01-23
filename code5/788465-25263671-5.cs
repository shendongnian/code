    string connStr = "Data Source=...";
    DataSet dataset = new DataSet();
    
    string connStr = ConfigurationManager.ConnectionStrings["OracleConn"].ToString();
    using (OracleConnection objConn = new OracleConnection(connStr))
    {
        OracleCommand cmd = new OracleCommand();
        cmd.Connection = objConn;
        cmd.CommandText = "Oracle_PkrName.Stored_Proc_Name";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("Emp_id", OracleType.Int32).Value = 3; // Input id
        cmd.Parameters.Add("Emp_out", OracleType.Cursor).Direction = ParameterDirection.Output;
    
        try
        {
            objConn.Open();
            cmd.ExecuteNonQuery();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dataset);                   
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Exception: {0}", ex.ToString());
        }
        objConn.Close();
    }
