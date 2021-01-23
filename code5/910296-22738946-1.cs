    private void BindData(string productName)
    {
        var dataTable = new DataTable();
        string sql = "SELECT UnitPrice, prdctName " + 
                     "FROM ProductDetails " + 
                     "WHERE prdctName = @prdctName";
        using (var conn = new SqlConnection(connectionString))
        {
            using (var cmd = new SqlCommand(sql, conn))
            {
                 cmd.Parameters.AddWithValue("@prdctName", productName);
                 using (var adapter = new SqlDataAdapter(cmd))
                 {
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                 }
             }
         }
    }
