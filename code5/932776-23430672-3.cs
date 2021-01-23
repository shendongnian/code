    using (var sqlconn = new SqlConnection(strConnectionString))
    {
        sqlconn.Open();
        string querySelectQuantity = "Select Quantity ...";
        using var (cmdOrder = new SqlCommand(querySelectQuantity, sqlconn))
        {
            int iQuantityDB;
            using (var sdRead = cmdOrder.ExecuteReader())
            {
                sdRead.Read();
                iQuantityDB = Convert.ToInt32(sdRead["Quantity"]);
            }   // Dispose reader
            // sqlconn.Close(); <-- Don't close
        } // cmdOrder disposed here
        if (iQuantityDB > iQuantity)
        {
            string InsertQuery = "INSERT INTO ...";
            using var (InsertCMD = new SqlCommand(InsertQuery, sqlconn))
            {
              // ...
            } // InsertCmd disposed here
        }
     } // Sql Connection disposed here
