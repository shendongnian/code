    System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("OriginalImagePath"));
    Bitmap bit = new Bitmap(img);
    System.Drawing.Image mask = System.Drawing.Image.FromFile(Server.MapPath("MaskImagePath"));
    Bitmap bitMask = new Bitmap(mask);
    for (int y = 0; y < img.Height; y++)
    {
        for (int x = 0; x < img.Width; x++)
        {
           if (bit.GetPixel(x, y).A != 0)
           {
                bit.SetPixel(x, y, bitMask.GetPixel(x, y));
                //bit.SetPixel(x, y, Color.Red);
           }
        }
    }
