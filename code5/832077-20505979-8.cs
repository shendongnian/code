    // Write to database like this - image is LONGBLOB type
    string sql = "INSERT INTO imagetable (image) VALUES (@file)";
    // remember 'using' statements to efficiently release unmanaged resources
    using (var conn = new MySqlConnection(cs))
    {
        conn.Open();
        using (var cmd = new MySqlCommand(sql, conn))
        {
            // parameterize query to safeguard against sql injection attacks, etc. 
            cmd.Parameters.AddWithValue("@file", File.ReadAllBytes(textBox1.Text));
            cmd.ExecuteNonQuery();
        }
    }
    // read image from database like this
    string sql = "SELECT image FROM imagetable WHERE ID = @ID";
    using (var conn = new MySqlConnection(cs))
    {
       conn.Open();
       using (var cmd = new MySqlCommand(sql, conn))
       {
          cmd.Parameters.AddWithValue("@ID", myInt);
          byte[] bytes = (byte[])cmd.ExecuteScalar();   
          using (var byteStream = new MemoryStream(bytes))
          {
             pictureBox1.Image = new Bitmap(byteStream);
          }
       }
    }
