    string query = "INSERT INTO MyTable VALUES (@MyValue)";
    SqlCommand cmd = new Sqlcommand(query, sqlConn);
    cmd.Parameters.Add("@MyValue", SqlDbType.Varcharm, 50).Value = myTextBox.Text;
    cmd.Connection.Open();
    try
    {
       cmd.ExecuteNonQuery();
    }
