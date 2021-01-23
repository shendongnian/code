    Bitmap original = new Bitmap(@"tree.jpg");
    Bitmap mask = new Bitmap(@"mask.jpg");
    int width = original.Width;
    int height = original.Height;
    // This is the color that will be replaced in the mask
    Color key = Color.FromArgb(0,255,0);
    // Processing one pixel at a time is slow, but easy to understand
    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            // Is this pixel "green" ?
            if (mask.GetPixel(x,y) == key)
            {
                // Copy the pixel color from the original
                Color c = original.GetPixel(x,y);
                // Into the mask
                mask.SetPixel(x,y,c);
            }
        }
    }
