        public Image Process(Image image)
        {
            Random rnd = new Random();
            Bitmap b = new Bitmap(image);
            BitmapData bData = b.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, b.PixelFormat);
            int bitsPerPixel = Image.GetPixelFormatSize(bData.PixelFormat);
            /*the size of the image in bytes */
            int size = bData.Stride * bData.Height;
            /*Allocate buffer for image*/
            byte[] data = new byte[size];
            /*This overload copies data of /size/ into /data/ from location specified (/Scan0/)*/
            System.Runtime.InteropServices.Marshal.Copy(bData.Scan0, data, 0, size);
            for (int i = 0; i < size; i += bitsPerPixel / 8)
            {
                if (data[i] == 0 && data[i + 1] == 0 && data[i + 2] == 0)
                {
                    var shouldChange = rnd.Next(0, 100) >= 50;
                    if (shouldChange)
                    {
                        data[i] = 255;
                        data[i + 1] = 255;
                        data[i + 2] = 255;
                    }
                }
            }
            /* This override copies the data back into the location specified */
            System.Runtime.InteropServices.Marshal.Copy(data, 0, bData.Scan0, data.Length);
            b.UnlockBits(bData);
            return b;
        }
