    private static string ConvertToString(Bitmap image)
    {
        StringBuilder result = new StringBuilder();
        StringBuilder imageLine = new StringBuilder();
        // Iterate each pixel from top to bottom
        for (int y = 0; y < image.Height; y++)
        {
            // Iterate each pixel from left to right
            for (int x = 0; x < image.Width; x++)
            {
                Color pixelColour = image.GetPixel(x, y);
                // Determine how "dark" the pixel via the Blue, Green, and Red values
                // (0x00 = dark, 0xFF = light)
                if (pixelColour.B <= 0xC8
                    && pixelColour.G <= 0xC8
                    && pixelColour.R <= 0xC8)
                {
                    imageLine.Append("1");	// Dark pixel
                }
                else
                {
                    imageLine.Append("0");	// Light pixel
                }
            }
            // Add line of zero's and one's to end results
            result.AppendLine(imageLine.ToString());
            imageLine.Clear();
        }
        return result.ToString();
    }
