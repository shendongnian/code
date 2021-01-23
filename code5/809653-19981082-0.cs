    [DllImport("user32.dll", SetLastError = true)]
    static extern bool OpenClipboard(IntPtr hWndNewOwner);
    [DllImport("user32.dll")]
    static extern IntPtr GetClipboardData(uint uFormat);
    [DllImport("user32.dll", SetLastError = true)]
    static extern bool CloseClipboard();
    [DllImport("user32.dll")]
    static extern bool EmptyClipboard();
    [DllImport("gdi32.dll")]
    static extern IntPtr CopyEnhMetaFile(IntPtr hemfSrc, string lpszFile);
    [DllImport("gdi32.dll")]
    static extern bool DeleteEnhMetaFile(IntPtr hemf);
    public Image GetMetaImageFromClipboard()
    {
        OpenClipboard(IntPtr.Zero);
        IntPtr pointer = GetClipboardData(14);
        string fileName = @"C:\Test\" + Guid.NewGuid().ToString() + ".emf";
        IntPtr handle = CopyEnhMetaFile(pointer, fileName);
        Image image;
        using (Metafile metafile = new Metafile(fileName))
        {
            image = new Bitmap(metafile.Width, metafile.Height);
            Graphics g = Graphics.FromImage(image);
            EmptyClipboard();
            CloseClipboard();
            g.DrawImage(metafile, 0, 0, image.Width, image.Height);
        }
        
        DeleteEnhMetaFile(handle);
        File.Delete(fileName);
        return image;
    }
