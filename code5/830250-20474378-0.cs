    private unsafe static void combine_img(Bitmap img1, Bitmap img2)
        {
            BitmapData image1 = img1.LockBits(new Rectangle(0, 0, img1.Width, img1.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData image2 = img2.LockBits(new Rectangle(0, 0, img2.Width, img2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int bytesPerPixel = 3;
            byte* scan1 = (byte*)image1.Scan0.ToPointer();
            int stride1 = image1.Stride;
            byte* scan2 = (byte*)image2.Scan0.ToPointer();
            int stride2 = image2.Stride;
            for (int y = 0; y < img1.Height; y++)
            {
                byte* row1 = scan1 + (y * stride1);
                byte* row2 = scan2 + (y * stride2);
                for (int x = 0; x < img1.Width; x++)
                {
                    if (row2[x * bytesPerPixel] == 255)
                        row1[x * bytesPerPixel] = row1[x * bytesPerPixel - 1] = row1[x * bytesPerPixel-2] = 255;
                }
            }
            img1.UnlockBits(image1);
            img2.UnlockBits(image2);
        }
