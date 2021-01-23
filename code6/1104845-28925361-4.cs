    for (int i = 0; i < bmp1.Width; i++)
    {
        for (int j = 0; j < bmp1.Height; j++)
        {
            double gray1 = (bmp1.GetPixel(i, j).R + bmp1.GetPixel(i, j).B + bmp1.GetPixel(i, j).G)/3d;
            double gray2 = (bmp2.GetPixel(i, j).R + bmp2.GetPixel(i, j).B + bmp2.GetPixel(i, j).G)/3d;
            double sum = Math.Pow(gray1 - gray2, 2)
            mseGray += sum;
        }
    }
    mse = (mseGray) / ((bmp1.Width * bmp1.Height) * 3);
