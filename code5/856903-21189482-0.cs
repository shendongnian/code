    string connectionString = myconnectionstringReadedFromFile;
    
    //
    // In a using statement, acquire the SqlConnection as a resource.
    //
    using (SqlConnection con = new SqlConnection(myconnectionstringReadedFromFile))
    {
        //
        // Open the SqlConnection.
        //
        con.Open();
      
        //.... your stuff
      
    }
