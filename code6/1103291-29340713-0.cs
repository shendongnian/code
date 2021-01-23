    //Create a new bitmap.
    var bmpScreenshot = new System.Drawing.Bitmap(Screen.PrimaryScreen.Bounds.Width, 
                                                  Screen.PrimaryScreen.Bounds.Height,
                                                  System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        
    // Create a graphics object from the bitmap.
    var gfxScreenshot = System.Drawing.Graphics.FromImage(bmpScreenshot);
        
    // Take the screenshot from the upper left corner to the right bottom corner.
    gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                                    Screen.PrimaryScreen.Bounds.Y,
                                                    0,
                                                    0,
                                                    Screen.PrimaryScreen.Bounds.Size,
                                                    System.Drawing.CopyPixelOperation.SourceCopy);
