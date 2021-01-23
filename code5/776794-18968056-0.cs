    void SetImageProgress(float percent, Bitmap img)
    {
       int alpha = (int)(percent / 100.0f * 255.0f);
       alpha &= 0xff;
       for(int x = 0; x < img.Width; x++)
       {
          for(int y = 0; y < img.Height; y++)
          {
             Color c = img.GetPixel(x, y);
             c = Color.FromArgb(alpha, c.R, c.G, c.B);
             img.SetPixel(x, y, c);
          }
       }
    }
