    float fx, fy;
    int x, y;
    bD = bmpBackClouds.LockBits(
    new System.Drawing.Rectangle(0, 0, bmpBackClouds.Width, bmpBackClouds.Height),
    System.Drawing.Imaging.ImageLockMode.ReadWrite,
    System.Drawing.Imaging.PixelFormat.Format32bppArgb);
