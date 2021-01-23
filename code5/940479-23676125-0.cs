                Image img = Image.FromFile(@"c:\temp\1.jpg");
            Bitmap resizedImg = new Bitmap(150, 150);
            double ratioX = (double)resizedImg.Width / (double)img.Width;
            double ratioY = (double)resizedImg.Height / (double)img.Height;
            double ratio = ratioX < ratioY ? ratioX : ratioY;
            
            int newHeight = Convert.ToInt32(img.Height * ratio);
            int newWidth = Convert.ToInt32(img.Width * ratio);
            using (Graphics g = Graphics.FromImage(resizedImg))
            {
                g.DrawImage(img, 0, 0, newWidth, newHeight);
            }
            resizedImg.Save(@"c:\temp\2.jpg");
