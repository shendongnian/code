    SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @yourtablename
    public List<string> GetColumnNames(string tableName)
    {
        List<string> columns = new List<string>();
        string strConnect = ".........";
        using (SqlConnection con = new SqlConnection(strConnect))
        {
             con.Open();
             using (SqlCommand com = new SqlCommand(@"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS 
                                                      WHERE TABLE_NAME = @yourtablename", con))
             {
          
                 com.Parameters.AddWithValue("@yourtableName", tableName);
                 using (SqlDataReader reader = com.ExecuteReader())
                 {
                     columns.Add(reader["COLUMN_NAME"].ToString());
                 }
             }
        }
        return columns;
    }
