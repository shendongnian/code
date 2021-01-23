    System.Drawing.Image image; //initialize it someway
    MemoryStream ms = new MemoryStream();
    image.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg); //if it is jpeg
    byte[] buffer = ms.ToArray();
    string serialized = Convert.ToBase64String(buffer);
