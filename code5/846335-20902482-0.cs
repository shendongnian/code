    Bitmap input = new Bitmap(@"G:\Greenbox.jpg");
    Bitmap output = new Bitmap(input.Width, input.Height);
    // Iterate over all piels from top to bottom...
    for (int y = 0; y < output.Height; y++)
    {
        // ...and from left to right
        for (int x = 0; x < output.Width; x++)
        {
            // Determine the pixel color
            Color camColor = input.GetPixel(x, y);
            // Every component (red, green, and blue) can have a value from 0 to 255, so determine the extremes
            byte max = Math.Max(Math.Max(camColor.R, camColor.G), camColor.B);
            byte min = Math.Min(Math.Min(camColor.R, camColor.G), camColor.B);
            // Should the pixel be masked/replaced?
            bool replace =
                camColor.G != min // green is not the smallest value
                && (camColor.G == max // green is the biggest value
                || max - camColor.G < 8) // or at least almost the biggest value
                && (max - min) > 96; // minimum difference between smallest/biggest value (avoid grays)
            if (replace)
                camColor = Color.Magenta;
            // Set the output pixel
            output.SetPixel(x, y, camColor);
        }
    }
