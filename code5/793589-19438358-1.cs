    public string GetData (string destinationFile)
    {
       using (SqlConnection con = new SqlConnection(connectionString))
       {
          using (SqlCommand sqlCmd = new SqlCommand(procedureName, con))
          {
          }
       } 
    }    
