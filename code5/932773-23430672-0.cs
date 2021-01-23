    using (var sqlconn = new SqlConnection(strConnectionString))
    {
        sqlconn.Open();
        string querySelectQuantity = "Select Quantity ...";
        using var (cmdOrder = new SqlCommand(querySelectQuantity, sqlconn))
        {
            using (var sdRead = cmdOrder.ExecuteReader())
            {
                sdRead.Read();
                int iQuantityDB = Convert.ToInt32(sdRead["Quantity"]);
                // sqlconn.Close(); <-- Don't close
               if (iQuantityDB > iQuantity)
               {
                  string InsertQuery = "INSERT INTO ...";
                  using var (InsertCMD = new SqlCommand(InsertQuery, sqlconn))
                  {
                    // Insert here
                  } // Command disposed here
               }
            } // Reader disposed here
        } // Command disposed here
     } // Sql Connection disposed here
