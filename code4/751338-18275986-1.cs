    for (int x = 0; x < bm.Width; x++) 
    {
    	for (int y = 0; y < bm.Height; y++) 
        {
    		Color c = bm.GetPixel(x, y);
    		if ((c.B + c.R + c.G > 660))
    			c = Color.FromArgb(0, c.R, c.G, c.B);
    		bm.SetPixel(x, y, c);
    	}
    }
