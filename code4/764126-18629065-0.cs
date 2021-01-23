    public void PD_PrintPage(object sender, PrintPageEventArgs e)
    {
        float W = e.MarginBounds.Width;
        
        // if you are calculating the whole page margin, then split it to carry 2 images
        
        float H = e.MarginBounds.Height / 2;
        // for space btwn images
        H -= 5.0;
        // First Image
            try
            {
                Bitmap Bmp = new Bitmap(BmpFiles[FileCounter]);
                if (Bmp.Width / W < Bmp.Height / H)
                    W = Bmp.Width * H / Bmp.Height;
                else
                    H = Bmp.Height * W / Bmp.Width;
                e.Graphics.DrawImage(Bmp, 0, 0, W, H);
                break;
            }
            catch
            {
            }
          FileCounter --;
          if (FileCounter < 0) goto goDaddy;
         //Second Img
            try
            {
                Bitmap Bmp = new Bitmap(BmpFiles[FileCounter]);
                if (Bmp.Width / W < Bmp.Height / H)
                    W = Bmp.Width * H / Bmp.Height;
                else
                    H = Bmp.Height * W / Bmp.Width;
                e.Graphics.DrawImage(Bmp, 0, H + 2.5, W, H);
                break;
            }
            catch
            {
            }        
        FileCounter --;
        
     goDaddy:;
        e.HasMorePages  = (FileCounter >= 0)
                
    }
