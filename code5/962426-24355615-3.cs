    public bool executeInsertprocedure(string spName, SqlParameter[] sqlParameters, out int message)
    { 
       try
        {
           cmd.ExecuteNonQuery();
           message = cmd.Parameters["@result"].Value;       
           (message == 1) ? return true : return false;
        }
    }
