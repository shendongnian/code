    public void addNewClient(DateTime entDate, client NewClient)
        {
            try
            {
                newCon = NewDB.GetConn(); // create connection 
                conn.Open(); //open connection 
    
                // create a command object identifying the stored procedure
                SqlCommand SqlCom = new SqlCommand("Store Procedure name", newConn);
    
               // add parameter to sql command, which is passed to the stored procedure
               SqlCom .Parameters.Add(new SqlParameter("@CName", NewClient.CName));
    
              // Rest of parameters
    
              // execute the command
              cmd.ExecuteReader();
          }
      }
