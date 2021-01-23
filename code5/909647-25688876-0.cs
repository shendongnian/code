    public static byte[] ImageTextMerge(Image imgBack, string str, Int32 x, Int32 y, Int32 w, Int32 h, Int32 width = 200, Int32 height = 200)
    {
        using (imgBack)
        {
            using (var bitmap = new Bitmap(width, height))
            {
                using (var canvas = Graphics.FromImage(bitmap))
                {
                    canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    canvas.DrawImage(imgBack, new Rectangle(0, 0, width, height), new Rectangle(0, 0, width, height), GraphicsUnit.Pixel);
                    // Create font and brush
                    Font drawFont = new Font("Arial", 20);
                    SolidBrush drawBrush = new SolidBrush(Color.Black);
                    // Create rectangle for drawing. 
                    RectangleF drawRect = new RectangleF(x, y, w, h);
                    // Draw rectangle to screen.
                    Pen blackPen = new Pen(Color.Transparent);
                    canvas.DrawRectangle(blackPen, x, y, w, h);
                    // Set format of string.
                    StringFormat drawFormat = new StringFormat();
                    drawFormat.Alignment = StringAlignment.Near;
                    // Draw string to screen.
                    canvas.DrawString(str, drawFont, drawBrush, drawRect, drawFormat);
                    canvas.Save();
                }
                try
                {
                    return ImageToByte(bitmap);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
