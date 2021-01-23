    string sFileData = "Hello World";
    string sFileName = "Bitmap.bmp";
    
    Font oFont = new Font("Arial", 11, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
    int iWidth = 0;
    int iHeight = 0;
    iWidth = (int)oGraphics.MeasureString(sFileData, oFont).Width;
    iHeight = (int)oGraphics.MeasureString(sFileData, oFont).Height;
    oBitmap = new Bitmap(oBitmap, new Size(iWidth, iHeight));
    
    using (Graphics oGraphics = Graphics.FromImage(oBitmap))
    {
        oGraphics.Clear(Color.White);
    
        oGraphics.DrawString(sFileData, oFont, new SolidBrush(System.Drawing.Color.Black), 0, 0);
    
        oGraphics.Flush();
    
    }
    
    oBitmap.Save(sFileName, System.Drawing.Imaging.ImageFormat.Bmp);
