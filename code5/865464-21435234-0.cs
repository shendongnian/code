    byte[] bytes = File.ReadAllBytes("File path and name");
    SqlConnection con = new SqlConnection("Connection string");
    SqlCommand command = new SqlCommand("INSERT INTO [tablename]([id], [image]) VALUES(@id,@image)", con);
    command.Parameters.AddWithValue("@id", 1);
    command.Parameters.AddWithValue("@image", bytes);
    con.Open();
    command.ExecuteNonQuery();
    con.Close();
