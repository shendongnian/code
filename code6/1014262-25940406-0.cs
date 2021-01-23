    using (SqlConnection con = new SqlConnection(strConnection))
    using (SqlCommand cmd = new SqlCommand("select companyLogo from companyDetailsTbl where companyId = 1", con))
    {
        con.Open();
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.HasRows)
            {
                reader.Read();
                pictureBox1.Image = ByteArrayToImage((byte[])(reader.GetValue(0)));
            }
        } 
    }
    public static Image ByteArrayToImage(byte[] byteArrayIn)
    {
        using (MemoryStream ms = new MemoryStream(byteArrayIn))
        { 
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
