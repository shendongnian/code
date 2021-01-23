    int width = 128;
    int height = 128;
    byte[] pixelData = new byte[4 * width * height];
    
    int index = 0;
    for (int y = 0; y < height; ++y)
        for (int x = 0; x < width; ++x)
        {
            pixelData[index++] = 255;  // B
            pixelData[index++] = 255;  // G
            pixelData[index++] = 255;  // R
            pixelData[index++] = 255;  // A
        }
