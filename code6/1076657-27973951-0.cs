    Bitmap ret = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(ret);
            g.Clear(Color.FromArgb(0,255,255,255));
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (!invert)
            {
                g.DrawImage(b, 0, 0, width, height);
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                g.FillPolygon(new SolidBrush(Color.Transparent), mask);
            }
            else g.FillPolygon(new TextureBrush(b), mask);
            return ret;
