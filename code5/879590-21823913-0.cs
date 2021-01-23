    string sql = " // here is my sql query ";
    string connectionstring = " // Here is my connection string.... ";
    using (SqlConnection connection = new SqlConnection(connectionstring))
    using (SqlCommand command = new SqlCommand(sql,connection)) 
    {
        connection.Open();
        bool? ev = (bool?)command.ExecuteScalar();
        if (ev.HasValue == true && ev.Value == true)
        {
            MessageBox.Show("some error");
        }
    }
