     Bitmap bmp = new Bitmap(file);
     int width = bmp.Width;
     int height = bmp.Height;
     int[] arr = new int[225];
     int i = 0;
     Color p;
    
     //Grayscale
     for (int y = 0; y < height; y++)
     {
         for (int x = 0; x < width; x++)
         {
             p = bmp.GetPixel(x,y);
             int a = p.A;
             int r = p.R;
             int g = p.G;
             int b = p.B;
             int avg = (r+g+b)/3;
             avg = avg < 128 ? 0 : 255;		// Converting gray pixels to either pure black or pure white
             bmp.SetPixel(x, y, Color.FromArgb(a, avg ,avg, avg));
         }
     }
     pictureBox2.Image = bmp; 
