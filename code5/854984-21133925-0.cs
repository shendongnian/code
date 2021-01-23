    using (SqlConnection connection = CreateSqlConnection(connString))
    {
        using (SqlCommand command = CreateSqlCommand()) 
        {
              try { //open connection, execute }
              catch { // log and handle exception }
              finally { // check connection state and close if required }
        }
    }
