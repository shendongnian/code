    public static void screenshots(string filename)
    {
        //Create a new bitmap.
        using( var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                       Screen.PrimaryScreen.Bounds.Height,
                                       PixelFormat.Format32bppArgb))
        {
            // Create a graphics object from the bitmap.
            using(var gfxScreenshot = Graphics.FromImage(bmpScreenshot))
            {
            
                // Take the screenshot from the upper left corner to the right bottom corner.
                gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                        Screen.PrimaryScreen.Bounds.Y,
                                        0,
                                        0,
                                        Screen.PrimaryScreen.Bounds.Size,
                                        CopyPixelOperation.SourceCopy);
            }
            // Save the screenshot to the specified path that the user has chosen.
            bmpScreenshot.Save(filename, ImageFormat.Gif);
        }
    }
