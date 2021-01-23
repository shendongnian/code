    public class DAL
    {
        public void InsertRequest(UserAndRequestInfo UInfo, UserCrops UCrop)
        {   
    	    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString))
            {
                conn.Open(); 
    	        SqlCommand command = conn.CreateCommand();
    	        SqlTransaction transaction;
    
                // Start a local transaction.
                transaction = conn.BeginTransaction("SampleTransaction");
                command.Connection = conn;
                command.Transaction = transaction;
    
                try
                {
                  command.CommandText = "Insert into ...";
                  command.ExecuteNonQuery();
                  command.CommandText = "Insert into ...";
                  command.ExecuteNonQuery();
    
                  // Attempt to commit the transaction.
                  transaction.Commit();
                }
                catch (Exception ex)
                {
                   // Attempt to roll back the transaction. 
                   try
                   {
                      transaction.Rollback();
                   }
                   catch (Exception ex2)
                   {
                      Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                      Console.WriteLine("  Message: {0}", ex2.Message);
                   }
                }
    	    }        
        }
        public void InsertBGs(BreedingGroups BG)
        {
    	
        }
    } 
