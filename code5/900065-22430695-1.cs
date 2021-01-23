    public static void AddMapFilePixelsToBitmapFromBuffer()
    {
        unsafe
        {
    		var backBuffer = (int*)bgWorker.pBackBuffer;
            //Write a mapfile into it´s position
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 256; y++)
                {
    				var index = x + (y * bgWorker.Width); // Assuming there's a width property somewhere, (Otherwise, this should be the same as Stride / 4)
    				var pixelColour = GetPixelColour(array[index]);
    				
    				// TODO: Find out which value to set.
    				// is color_data actually pixelColour?
    				// what type is pixelColour?
    				// are you working with ARGB, BGRA or RGB?
    
    				backBuffer[index] = pixelColour;
    			}
            }
        }
    }
