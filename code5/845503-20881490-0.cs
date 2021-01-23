    public DataTable LoadData()
        {
            DataTable dataTable;
            string connString = @"your connection string here";
            string query = "SELECT * FROM Usergroups t1 INNER JOIN Groups t2 ON t2.GroupID=t1.GroupID WHERE t1.UserID=@name";
    
            SqlConnection conn = new SqlConnection(connString);        
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
    
            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(dataTable);
            conn.Close();
            return dataTable;
        }
