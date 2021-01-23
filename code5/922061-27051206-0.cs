            int width = 800, height = 600;
            var bit = new Bitmap(width, height);
            var g = Graphics.FromImage(bit);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var area = new Rectangle(0, 0, width, height);
            g.FillRectangle(new LinearGradientBrush(area, Color.PaleGoldenrod, Color.OrangeRed, 45), area);
            g.DrawImage(Image.FromFile(@"your image"), new Point(10, 10));
            g.DrawString("sample", new System.Drawing.Font("Tahoma", 56), new SolidBrush(Color.Black), new PointF(50, 50));
            pictureBox1.Image = bit;
        
