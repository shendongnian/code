    private void GetColumnNames(string tableName)
    {
        string query = "SELECT * FROM myDatabase.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @TableName";
        using (var conn = new SqlConnection(myConnectionString))
        using (var cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@TableName", tableName)
            conn.Open();
            var reader = cmd.ExecuteReader();
            //Store the contents of reader in a variable to update your list box.
        }
    }
