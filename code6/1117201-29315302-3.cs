    string testText = "The quick brown fox <_>°|^ 123456789-0!";
    using (Graphics G = Graphics.FromImage(bmp0))
    using (Font font = new Font("Smallest Pixel-7", 10f))
    {
        G.TextContrast = 0;
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
        G.DrawString(testText, font, Brushes.Black, new Point(20, 20));
    }
