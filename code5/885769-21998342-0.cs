    public static Bitmap ConvertToGrayScale(this Bitmap me)
    {
         if (me == null)
             return null;
    
         var radius = 20, x = me.Width / 2, y = me.Height / 2;
         using (Bitmap maskImage = new Bitmap( me.Width, me.Height, PixelFormat.Format8bppIndexed);)
         {
            using (Graphics g = Graphics.FromImage(maskImage))
               using (Brush b = new SolidBrush(ColorTranslator.FromHtml("#00000000")))
                  g.FillEllipse(b, x, y, radius, radius);
            // first convert to a grey scale image
            var maskedFilter = new MaskedFilter(new Grayscale(0.2125, 0.7154, 0.0721), maskImage);
    
            return maskedFilter.Apply(me);
         }
    }
    
