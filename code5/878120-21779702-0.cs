    static void Main(string[] args)
        {
            int _newWidth = 60; //the new width is set, the height will be calculated
    
            var originalImage = Bitmap.FromFile(@"C:\temp\source.png");
    
            float factor = originalImage.Width / (float)_newWidth;
            int newHeight = (int)(originalImage.Height / factor);
    
            Bitmap resizedImage = ResizeBitmap(originalImage, _newWidth, newHeight);
    
            resizedImage.Save(@"c:\temp\target.png");
        }
    
        private static Bitmap ResizeBitmap(Image b, int nWidth, int nHeight)
        {
            Bitmap result = new Bitmap(nWidth, nHeight);
            using (Graphics g = Graphics.FromImage(result))
                g.DrawImage(b, 0, 0, nWidth, nHeight);
            return result;
        }
