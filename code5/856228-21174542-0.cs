    public List<SalesList> ExecuteSales(List<string> items, int storeID, int W1, int W2, int vendorID, int retailerID)
    {
        var sales = new List<SalesList>();
        var table = new DataTable();
        table.Columns.Add("ItemNumber");
        foreach (var item in items)
        {
            table.Rows.Add(item);
        }
        using (var connection = new SqlConnection("ConnectionString"))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "cp_ExecuteSales";
                command.Parameters.AddWithValue("@RetailerID", retailerID);
                command.Parameters.AddWithValue("@VendorID", vendorID);
                command.Parameters.AddWithValue("@StoreID", storeID);
                var tvp = new SqlParameter("@ItemIds", SqlDbType.Structured)
                {
                     TypeName = "tvpItems",
                     Value = table
                };
                command.Parameters.Add(tvp);
                using (var reader = command.ExecuteReader())
                {
                    //DoWork
                }
            }
        }
        return sales;
    }
