    Binding b = new Binding("Image", dataset, "Timage.imagee", true);
    b.Format += picFormat;
    pictureBox1.DataBindings.Add(b);
    private void pic_Format(object sender, ConvertEventArgs e)
    {
      Bitmap bmp = null;
      byte[] img = (byte[])e.Value;
      using (MemoryStream ms = new MemoryStream()) {
        ms.Write(img, 0, img.Length);
        bmp = new Bitmap(ms);
      }
      if (bmp != null) {
        e.Value = bmp;
      }
    }
