            using(Graphics g = Graphics.FromImage((Image)b))
            {
                 g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                 g.CompositingQuality = CompositingQuality.HighSpeed;
                 g.SmoothingMode = SmoothingMode.HighSpeed;
                 g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            }
            return b;
    
