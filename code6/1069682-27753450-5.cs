    Byte[] bytes = null;
    if (FileUpload1.HasFile)
    {
        Stream fs = FileUpload1.PostedFile.InputStream;
        BinaryReader br = new BinaryReader(fs);
        bytes = br.ReadBytes((Int32)fs.Length);
    }
    string cs = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    SqlConnection con = new SqlConnection(cs);
    SqlCommand cmd = new SqlCommand("INSERT INTO disc_info (disc_name,menu) VALUES(@disc, @menu)", con);
    cmd.Parameters.AddWithValue("@disc", TextBox.Text);
    cmd.Parameters.AddWithValue("@menu", bytes);
    con.Open();
    cmd.ExecuteNonQuery();   
