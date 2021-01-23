    public int GetColumnMaxLength(string tableName, string columnName)
    {
        string query = @"SELECT max_length
                         FROM sys.columns c 
                         INNER JOIN sys.tables t ON t.object_id = c.object_id
                         WHERE t.Name = @TableName
                         AND c.Name = @ColunmName";
        
        int result = -1;
        
        using (SqlConnection conn = new SqlConnection("your-connection-string-here"))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.Add("@TableName", SqlDbType.VarChar, 100).Value = tableName;
            cmd.Parameters.Add("@ColumnName", SqlDbType.VarChar, 100).Value = columnName;
            
            conn.Open();
            result = (int)cmd.ExecuteScalar();
            conn.Close();
        }
        
        return result;
    }
   
