    Byte[] bytes = null;
    if (FileUpload1.HasFile)
    {
        string filename = FileUpload1.PostedFile.FileName;
        string filePath = Path.GetFileName(filename);
        Stream fs = FileUpload1.PostedFile.InputStream;
        BinaryReader br = new BinaryReader(fs);
        bytes = br.ReadBytes((Int32)fs.Length);
        string hex = "0x" + BitConverter.ToString(bytes).Replace("-", "");
    }
    string cs = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    SqlConnection con = new SqlConnection(cs);
    SqlCommand cmd = new SqlCommand("INSERT INTO disc_info (disc_name,menu) VALUES('" + TextBox.Text + "'," + hex + ")", con);
  
    con.Open();
    cmd.ExecuteNonQuery();             
