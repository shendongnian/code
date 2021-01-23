    SqlCommand cmd = new SqlCommand("Select img from tbImage where id = " + id, con);
    con.Open();
    SqlDataReader reader = cmd.ExecuteReader();
    if (reader.HasRows)
    {
        while (reader.Read())
        {
            byte[] img = (byte[])reader["img"];
            MemoryStream ms = new MemoryStream(img);
            PictureBox1.Image = Image.FromStream(ms);
        }
    }
    con.Close();
