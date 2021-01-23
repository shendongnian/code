    using (SqlConnection myConn = new SqlConnection(connstring))
    {
        myConn.Open();
        // execute first statement
    }
    
    
    using (SqlConnection myConn2 = new SqlConnection(connstring))
    {
        myConn2.Open();
        // execute second statement
    }
