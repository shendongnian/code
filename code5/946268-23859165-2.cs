    using (
    SqlConnection connection = new SqlConnection(strCon)) // strCon is the string containing connection string
    {
        SqlCommand command = new SqlCommand("select * from tbllogin", connection);
        connection.Open();
        DataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString(int index)); // index of column you want, because this method takes only int
            }
        } 
        reader.Close();
    }
