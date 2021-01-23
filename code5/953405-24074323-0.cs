    using (var connection = new SqlConnection("Your connection string"))
    {
        int orderID;    
        using (var command = new SqlCommand("INSERT INTO Orders (Created,OrderTotal) VALUES (GetDate(),@OrderTotal); SELECT CONVERT(int, SCOPE_IDENTITY()) as OrderID;", connection))
        {
            command.Parameters.AddWithValue("@OrderTotal", 10.0f);
            connection.Open();
            orderID = (int)command.ExecuteScalar();
        }
        //... now you can use orderID in your next query to insert an OrderLine
    }
