    public bool executeInsertprocedure(string spName, SqlParameter[] sqlParameters, out int message)
    { 
       try
        {
           cmd.ExecuteNonQuery();
           message = cmd.sqlParameters["@result"].Value;       
           (message == 1) ? return true : return false;
        }
    }
