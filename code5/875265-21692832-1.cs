    string constring = System.Configuration.ConfigurationManager.ConnectionStrings["SRKBS-PB"].ConnectionString;
    using(conDB = new SqlConnection(constring))
    using(cmd = new SqlCommand("sp_GetDeity", conDB))
    {
        conDB.Open(); // open the connection
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
    
        DataTable dt = new DataTable();
        dt.Load(cmd.ExecuteReader());
    
        return dt;
    }
