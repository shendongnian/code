    public static class GraphicsHelper {
        public static SizeF MeasureString(string s, Font font) {
            SizeF result;
            using (var image = new Bitmap(1, 1)) {
                using (var g = Graphics.FromImage(image)) {
                    result = g.MeasureString(s, font);
                }
            }
         return result;
        }
    }
    string sFileData = "Hello World";
    string sFileName = "Bitmap.bmp";
    
    Font oFont = new Font("Arial", 11, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
    var sz = GraphicsHelper.MeasureString(sFileData, oFont);
    var oBitmap = new Bitmap((int)sz.Width, (int)sz.Height);
    using (Graphics oGraphics = Graphics.FromImage(oBitmap)) {
        oGraphics.Clear(Color.White);
        oGraphics.DrawString(sFileData, oFont, new SolidBrush(System.Drawing.Color.Black), 0, 0);
        oGraphics.Flush();
    }
    
    oBitmap.Save(sFileName, System.Drawing.Imaging.ImageFormat.Bmp);
