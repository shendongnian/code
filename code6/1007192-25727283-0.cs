    private static void ResizeImage(string file, double vscale, double hscale, string output)
    {
         using(var source = Image.FromFile(file))
         {
              var width = (int)(source.Width * vscale);
              var height = (int)(source.Height * hscale);
              using(var image = new Bitmap(width, height, PixelFormat.Format24bppRgb))
                   using(var graphic = Graphics.FromImage(image))
                   {
                        graphic.SmoothingMode = SmoothingMode.AntiAlias;
                        graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        graphic.DrawImage(source, new Rectangle(0, 0, width, height));
                        image.Save(output);
                   }
         }
    }
