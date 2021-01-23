    string strConnectionString = @"......;MultipleActiveResultSets=True;";
    using(SqlConnection sqlconn = new SqlConnection(strConnectionString))
    {
        sqlconn.Open();
        string querySelectQuantity = @"Select Quantity from dbo.JeanProduct 
                                       WHERE ProductID = @id";
        using(SqlCommand cmdOrder = new SqlCommand(querySelectQuantity, sqlconn))
        {
            cmdOrder.AddWithValue("@id", Convert.ToInt32(txtProductID.Text));
            using(SqlDataReader sdRead = cmdOrder.ExecuteReader())
            {
                if(sdRead.Read())
                {
                    .....
                    string InsertQuery = @"INSERT INTO Sale(SaleID, CustomerID, ProductID, 
                        Price, Quantity, Subtotal, GST, Total)VALUES(@iCustomerID, 
                        @iProductID, @dPrice, @iQuantity, 
                        @dSubtotal, @dGST, @Total)";
                        using(SqlCommand InsertCMD = new SqlCommand(InsertQuery, sqlconn))
                        {
                             InsertCMD.Parameters.AddWithValue("@iCustomerID", iCustomerID);  
                             ....
                             InsertCMD.ExecuteNonQuery();
                             LoadDataonTable(); 
                        }
                 }
                 else
                 {
                      MessageBox.Show("no more stock");
                 }
             }
        }
    }
