    <img runat="server" id="image1" alt="" src="" height="100" width="100" />
    protected void LoadImage1()
    {
        SqlCommand cmd = new SqlCommand("sps_getimage", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@flag", 1);
        cmd.Parameters.AddWithValue("@ad_id", ad_id);
        con.Open();
        SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.SequentialAccess);
        if (reader.HasRows)
        {
            reader.Read();
            MemoryStream memory = new MemoryStream();
            long startIndex = 0;
            const int ChunkSize = 256;
            while (true)
            {
                byte[] buffer = new byte[ChunkSize];
                long retrievedBytes = reader.GetBytes(0, startIndex, buffer, 0, ChunkSize);
                memory.Write(buffer, 0, (int)retrievedBytes);
                startIndex += retrievedBytes;
                if (retrievedBytes != ChunkSize)
                    break;
            }
 
            byte[] data = memory.ToArray();
            img1 = data;
            memory.Dispose();
            image1.Src = "data:image/png;base64," + Convert.ToBase64String(data);
        }
        con.Close();
    }
