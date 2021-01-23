    int size = buffer.FrameType.BufferSize;
    int height = buffer.FrameType.Height;
    byte[] img = new byte[size];
    int lineSize = buffer.BytesPerLine;
    //for each row of the image
    for (int row = 0; row < height; row++)
    {
         //For each byte on a row
         for (int col = 0; col < lineSize; col++)
         {
               int newIndex = (size - (lineSize * (row + 1))) + col;
               img[newIndex] = buffer[col, row];
         }
    }
