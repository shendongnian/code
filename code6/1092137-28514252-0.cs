    using(var connection = new SqlConnection(connectionString))
    using(var cmd = connection.CreateCommand())
    { 
        cmd.CommandText = "INSERT INTO Table(Artist, Album, [Release Year]) VALUES(@Artist, @Album, @ReleaseYear)";
        cmd.Parameters.Add(@Artist, SqlDbType.NVarChar).Value = textBox1.Text;
        cmd.Parameters.Add(@Album, SqlDbType.NVarChar).Value = textBox2.Text;
        cmd.Parameters.Add(@ReleaseYear, SqlDbType.NVarChar).Value = textBox3.Text;
        connection.Open();
        cmd.ExecuteNonQuery();
    }
