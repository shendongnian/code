    OracleConnection conn = new OracleConnection();
    conn.ConnectionString = txtconnection.Text;
    conn.Open();
    OracleCommand objCmd = new OracleCommand();
    objCmd.Connection = conn;
    objCmd.CommandType = CommandType.StoredProcedure;
    objCmd.CommandText = "SELECT * FROM DEPARTMENTS_VIEW";
    
    DataSet ds = new DataSet();
    OracleDataAdapter oraDa = new OracleDataAdapter(objCmd);
    oraDa.Fill(ds, "department");
    gvGET_DEPARTMENTS.DataSource = ds.Tables["department"];
    gvGET_DEPARTMENTS.DataBind();
    conn.Close();
