    public  string  Decrypt()
     {
    	 using (var cn = new SqlConnection(((EntityConnection) ObjectContext.Connection).StoreConnection.ConnectionString))
    	 {
    		 try
    		 {		 
    			 cn.Open();
    			 
    			 var sqlcmd = new SqlCommand("[dbo].[DecryptCCode]", cn);
    			 
    			 // specify the command is a Stored Procedure
    			 sqlcmd.CommandType = CommandType.StoredProcedure;
    			 
    			 sqlcmd.Parameters.Add("@decryptedStr", SqlDbType.NChar, 5);
    			 sqlcmd.Parameters["@decryptedStr"].Direction = ParameterDirection.Output;
    			 			 
    			 sqlcmd.ExecuteNonQuery();			
    			 
    			 return sqlcmd.Parameters["@decryptedStr"].Value != DBNull.Value ? (string)sqlcmd.Parameters["@decryptedStr"].Value : string.Empty;
    		 }
    		 catch (Exception e)
    		 {
    			 Console.WriteLine(e.Message);
    			 return string.Empty;
    		 }
    		 finally
    		 {
    			cn.Close();
    		 }
    	 }
     }
