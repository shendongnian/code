    var height = bmp1.Height;
    var width = bmp1.Width;
    var pixelBytes1 = new byte[height * width * 4];
    var pixelBytes2 = new byte[height * width * 4];
    bmp1.CopyPixels(pixelBytes1, stride, 0);
    bmp2.CopyPixels(pixelBytes2, stride, 0);
    for (int x = 0; x < width; x++)
    {
        int woff = x * height;
        for (int y = 0; y < height; y++)
        {
            int index = woff + y;
            double gray1 = (bmp1[index] + bmp1[index+1]+ bmp1[index+2])/3d;
            double gray2 = (bmp2[index] + bmp2[index+1]+ bmp2[index+2])/3d;
            double sum = Math.Pow(gray1 - gray2, 2)
            mseR += sum;
            mseG += sum;
            mseB += sum;
        }
    }
