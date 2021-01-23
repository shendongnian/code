    private Bitmap Screenshot()
    {
        //Create a bitmap with the same dimensions like the screen
        Bitmap screen = new Bitmap(SystemInformation.VirtualScreen.Width,
                                             SystemInformation.VirtualScreen.Height);
     
        //Create graphics object from bitmap
        Graphics g = Graphics.FromImage(screen);
     
        //Paint the screen on the bitmap
        g.CopyFromScreen(SystemInformation.VirtualScreen.X,
                                 SystemInformation.VirtualScreen.Y,
                                 0, 0, screen.Size);
        g.Dispose();
     
        //return bitmap object / screenshot
        return screen;
    }
