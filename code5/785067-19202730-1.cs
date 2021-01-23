    Color black = System.Drawing.Color.FromArgb(0, 0, 0);
    Color white = System.Drawing.Color.FromArgb(255, 255, 255);
    
    int lowerBound = (int)((float)lowerBoundPercent * 255.0 / 100.0) * 3;
    int upperBound = (int)((float)upperBoundPercent * 255.0 / 100.0) * 3;
    Parallel.For(0, width, k =>
        {
            for (int j = 0; j < height; j++)
            {
                    Color pixelColor;
                    int grayscaleValue;
                    pixelColor = color[k][j];
                    grayscaleValue = (pixelColor.R + pixelColor.G + pixelColor.B);
                    if (grayscaleValue >= lowerBound && grayscaleValue <= upperBound)
                        color[k][j] = white;
                    else
                        color[k][j] = black;
            }
        });
