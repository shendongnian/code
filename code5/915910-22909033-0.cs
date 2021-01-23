    if (img2.Width == img1.Width && img2.Height == img1.Height)
    {
         for (int i = 0; i < img2.Width; i++)
         {
               for (int j = 0; j < img2.Height; j++)
               {
                   var firstPixel = img2.GetPixel(i, j).ToString();
                   var secondPixel = img1.GetPixel(i, j).ToString();
                   // skip all non opaque pixels!
                   if firstPixel.A != 255 continue;  
                   if (firstPixel != secondPixel)
                   {
                       imgeq = false;
                       break;
                   }
               }
          }
     }
     else
     {
         imgeq = false;
     }
