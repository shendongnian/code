    for (int i = 0; i < bmp1.Width; i++)
    {
        for (int j = 0; j < bmp1.Height; j++)
        {
            // As a grayscale image has rthe same color on all RGB just pick one
            int gray1 = bmp1.GetPixel(i, j).R;
            int gray2 = bmp2.GetPixel(i, j).R;
            double sum = Math.Pow(gray1 - gray2, 2)
            mseGray += sum;
        }
    }
    mse = (mseGray) / ((bmp1.Width * bmp1.Height) * 3);
