        public Image stringToImage(string inputString)
        {
            string text = inputString.Trim();
            Bitmap bmp = new Bitmap(1, 1);
            //Set the font style of output image
            Font font = new Font("Arial", 25, FontStyle.Regular, GraphicsUnit.Pixel);
            Graphics graphics = Graphics.FromImage(bmp);
            int width = (int)graphics.MeasureString(text, font).Width;
            int height = (int)graphics.MeasureString(text, font).Height;
            bmp = new Bitmap(bmp, new Size(width, height));
            graphics = Graphics.FromImage(bmp);
            //Specify the background color of the image
            graphics.Clear(Color.Cyan);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            //Specify the text, font, Text Color, X position and Y position of the image
            graphics.DrawString(text, font, new SolidBrush(Color.Black), 0, 0);
            graphics.Flush();
            graphics.Dispose();
            //if you want to save the image  uncomment the below line.
            //bmp.Save(@"d:\myimage.jpg", ImageFormat.Jpeg);
            return bmp;
        }
