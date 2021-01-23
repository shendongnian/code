    Dictionary<int, byte[]> images = new Dictionary<int, byte[]>();
    public Dictionary<int, byte[]> GetImages()
    {
        Dictionary<int, byte[]> data = new Dictionary<int, byte[]>();
        SqlConnection con = new SqlConnection("Your connection string");
        SqlCommand command = new SqlCommand("SELECT * FROM [tablename]", con);
        con.Open();
        SqlDataReader sdr = command.ExecuteReader();
        while(sdr.Read())
        {
            data.Add((int)sdr["id"], (byte[])sdr["image"]);
        }
        con.Close();
        return data;
    }
