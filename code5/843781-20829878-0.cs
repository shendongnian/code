    string filename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "image.png");
    
    Bitmap b = new System.Drawing.Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
    Graphics g = Graphics.FromImage(b);
    g.CopyFromScreen(0, 0, 0, 0, b.Size);
    
    Bitmap b2 = new Bitmap(500, 500);
    g = Graphics.FromImage(b2);
    g.DrawImage(b, new RectangleF(0, 0, b2.Width, b2.Height));
    
    b2.Save(filename, ImageFormat.Jpeg);
    System.Diagnostics.Process.Start(filename);
