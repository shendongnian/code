    private Bitmap GenerateColorImage(Color color)
            {
                Bitmap colorimage = new Bitmap(16, 16) ;
                using (Graphics graphics = Graphics.FromImage(colorimage))
                {
                    graphics.Clear(color);
                    using (SolidBrush brush = new SolidBrush(colorimage)
                    {
                       graphics.FillRectangle(brush, 0, 0, 16, 16);
                    }
    
                }
                return colorimage;
            }
