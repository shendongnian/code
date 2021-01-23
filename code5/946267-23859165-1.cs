    using (
    SqlConnection connection = new SqlConnection(strCon))
    {
        SqlCommand command = new SqlCommand("select * from tbllogin", connection);
        connection.Open();
        DataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                x = reader.GetString(int index); // index of column you want, because this method takes only int
            }
        } 
    
        reader.Close();
    }
