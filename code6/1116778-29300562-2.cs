    protected DataTable GetAllMessages()
    {
        using (SqlConnection connection = new SqlConnection(Common.ConnectionString))
        {
            string myQuery = @"SELECT MESSAGES FROM MYTABLE";
    
            using (SqlCommand cmd = new SqlCommand(myQuery, connection))
            {
                connection.Open();
    
                using (SqlDataReader reader = cmd.ExecuteDataSet(cmd, CommandType.Text, myQuery))
                //return DataTable
            }
        }
    }
 
