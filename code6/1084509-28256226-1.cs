    ..
    Bitmap newbmp = new Bitmap(512, 512);
    foreach (Point s in CommonList)
    {
        Console.WriteLine("The following points are the same" + s);
        newbmp.SetPixel(s.X, s.Y, Color.Red);
    }
    using (Graphics G = Graphics.FromImage(newbmp))
    {
        G.DrawRectangle(Pens.Red, yourRectangle);
        .. 
    }
    newbmp.Save(@"c:\newbmp\newbmp.bmp", ImageFormat.Bmp);
    newbmp.Dispose();
