    byte[] b = System.IO.File.ReadAllBytes("filepath");
    System.IO.MemoryStream imgStream = new System.IO.MemoryStream();
    imgStream.Write(b, 0, b.Length);
    System.Drawing.Image img;
    img = System.Drawing.Image.FromStream(imgStream);
    //use this image as Image of pictureBox
