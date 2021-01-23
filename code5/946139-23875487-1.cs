    for (int row = 0; row < b.Height; ++row)
    {
        int rowStart = row * bmpData.Stride;
        for (int column = 0; column < b.Width; ++column)
        {
            rgbValues[rowStart + column] = GetColorForPixel(column, row);
        }
    }
