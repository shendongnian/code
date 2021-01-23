    private void DrawRectangle()
    {
        string imageFilePath = @"c:\Test.jpg";
        int rectHeight = 100;
        using (Image img = Image.FromFile(imageFilePath)) // load original image
        using (Bitmap bitmap = new Bitmap(img.Width, img.Height + rectHeight)) // create blank bitmap of desired size
        using (Graphics graphics = Graphics.FromImage(bitmap))
        {
            // draw existing image onto new blank bitmap
            graphics.DrawImage(img, 0, 0, img.Width, img.Height); 
            SolidBrush brush = new SolidBrush(Color.Black);
            // draw your rectangle below the original image
            graphics.FillRectangle(brush, 0, img.Height, img.Width, rectHeight); 
            bitmap.Save(@"c:\Test1.bmp");
        }
    }
