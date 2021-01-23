    for (int i = 0; i < bmp1.Width; i++)
    {
        for (int j = 0; j < bmp1.Height; j++)
        {
            int gray1 = bmp1.GetPixel(i, j).R*0.3 + bmp1.GetPixel(i, j).B*0.11 + bmp1.GetPixel(i, j).G*0.59;
            int gray2 = bmp2.GetPixel(i, j).R*0.3 + bmp2.GetPixel(i, j).B*0.11 + bmp2.GetPixel(i, j).G*0.59;
            double sum = Math.Pow(gray1 - gray2, 2)
            mseGray += sum;
        }
    }
    mse = (mseGray) / ((bmp1.Width * bmp1.Height) * 3);
