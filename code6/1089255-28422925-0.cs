    Bitmap m_back = new Bitmap(bmp2.Width, bmp2.Height);
    for (int y = 0; y < bmp2.Height; y++)
    {
         for (int x = 0; x < bmp2.Width; x++)
         {
              Color temp = Color.FromArgb(80, bmp2.GetPixel(x, y));
              m_back.SetPixel(x, y, temp);
         }
    }
    Bitmap bmp3 = new Bitmap(MergeTwoImages(bmp1, m_back));
