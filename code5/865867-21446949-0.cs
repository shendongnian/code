    public IEnumerable<int> GetOrderIds()
    {
        var ids = new List<int>();
        var queryString = "SELECT OrderID FROM dbo.Orders;";
        using (var connection = new SqlConnection(connectionString))
        using (var command = new SqlCommand(queryString, connection))
        {
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                 while (reader.Read())
                 {
                    var id = reader.GetInt32(0);
                    ids.Add(id);
                 }
            }
        }
        return ids;
    }
