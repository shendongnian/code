    Image img = Image.FromFile(@"C:\Lenna.jpg");
    byte[] arr;
    using (MemoryStream ms = new MemoryStream())
    {
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        arr =  ms.ToArray();
    }
    
    ommand.CommandText = "INSERT INTO ImagesTable (Image) VALUES('" + arr + "')";
      command.CommandType = CommandType.Text;
      command.ExecuteNonQuery();
