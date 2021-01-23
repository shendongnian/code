        protected DataTable GetAllMessages()
        {
            using (SqlConnection connection = new SqlConnection(Common.ConnectionString))
            {
                string myQuery = @"SELECT MESSAGES FROM MYTABLE";
        
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
    
                DataSet messagesDS = new DataSet();
                adapter.Fill(messagesDS, "MYTABLE");
    
                return messagesDS.Tables[0];
            }
        }
 
