    int maxId = -1;
    if (customer_IDTextBox == null)
    {
        using (var sqlConnection = new SqlConnection(/* your connection string */))
        {
            sqlConnection.Open();
            string query = "SELECT MAX(Customer_ID) FROM Customer";
            using (var sqlCommand = new SqlCommand(query, sqlConnection))
            {
                maxId = Convert.ToInt32(sqlCommand.ExecuteScalar());
            }
        }
    }
