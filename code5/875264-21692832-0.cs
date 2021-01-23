    using(conDB = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["SRKBS-PB"]))
    using(cmd = new SqlCommand("sp_GetDeity", conDB))
    {
        conDB.Open(); // open the connection
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
    
        DataTable dt = new DataTable();
        dt.Load(cmd.ExecuteReader());
    
        return dt;
    }
