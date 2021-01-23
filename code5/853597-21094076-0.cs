    // Load image   
    Bitmap bm = new Bitmap("D:\\a.png");
        
    for (int i = 0; i < bm.Width; i++)
    {
        for (int j = 0; j < bm.Height; j++)
        {
            // Handles transparent pixles
            if (bm.GetPixel(i, j).R == 0 & bm.GetPixel(i, j).G == 0 & bm.GetPixel(i, j).B == 0 & bm.GetPixel(i, j).A == 0) bm.SetPixel(i, j, Color.Transparent);
            // Passes the grey component of the grescale image to R and G compenents and changes pixle color
            else bm.SetPixel(i, j, Color.FromArgb(bm.GetPixel(i, j).R, bm.GetPixel(i, j).R, 0));
        }
    }
    
    // Save image
    bm.Save("D:\\b.png");
