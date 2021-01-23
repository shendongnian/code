        private static unsafe void CombineImage(Bitmap image1, Bitmap image2, int index)
        {
            Dictionary<long, int> testDict = new Dictionary<long, int>(); ;
            var combinedBitmap = new Bitmap(image1.Width, image1.Height, image1.PixelFormat);
            BitmapData bData1 = image1.LockBits(new Rectangle(0, 0, image1.Width, image1.Height), ImageLockMode.ReadOnly, image1.PixelFormat);
            BitmapData bData2 = image2.LockBits(new Rectangle(0, 0, image2.Width, image2.Height), ImageLockMode.ReadOnly, image2.PixelFormat);
            BitmapData bDataCombined = combinedBitmap.LockBits(new Rectangle(0, 0, combinedBitmap.Width, combinedBitmap.Height), ImageLockMode.WriteOnly, combinedBitmap.PixelFormat);
            byte* dataBase = (byte*)bData1.Scan0.ToPointer();
            byte* dataDetail = (byte*)bData2.Scan0.ToPointer();
            byte* dataCombined = (byte*)bDataCombined.Scan0.ToPointer();
            const int bitsPerPixel = 24;
            const int xIncr = bitsPerPixel / 8;
            var t = new Vec3f(0);
            var u = new Vec3f(0);
            var r = new Vec3f(0);
            int h = bData1.Height, w = bData1.Width;
            long key;
            int value;
            Stopwatch combineStopwatch = Stopwatch.StartNew();
            for (int y = 0; y < h; ++y)
            {
                for (int x = 0; x < w; ++x)
                {
                    key = dataBase[0] | (dataBase[1] << 8) | (dataBase[2] << 16) | (dataDetail[0] << 24) | (dataDetail[1] << 32) | (dataDetail[2] << 40);
                    if (testDict.ContainsKey(key))
                    {
                        value = testDict[key];
                        dataCombined[0] = (byte)(value & 255);
                        dataCombined[1] = (byte)((value >> 8) & 255);
                        dataCombined[2] = (byte)((value >> 16) & 255);
                    }
                    else
                    {
                        t.z = (dataBase[0] / 255.0f) * 2.0f;
                        t.y = (dataBase[1] / 255.0f) * 2.0f - 1.0f;
                        t.x = (dataBase[2] / 255.0f) * 2.0f - 1.0f;
                        u.z = (dataDetail[0] / 255.0f) * 2.0f - 1.0f;
                        u.y = (dataDetail[1] / 255.0f) * -2.0f + 1.0f;
                        u.x = (dataDetail[2] / 255.0f) * -2.0f + 1.0f;
                        r = t * t.Dot(u) - u * t.z;
                        r.Normalize();
                        //Write data to our new bitmap
                        dataCombined[0] = (byte)Math.Round((r.z * 0.5f + 0.5f) * 255.0f);
                        dataCombined[1] = (byte)Math.Round((r.y * 0.5f + 0.5f) * 255.0f);
                        dataCombined[2] = (byte)Math.Round((r.x * 0.5f + 0.5f) * 255.0f);
                        value = dataCombined[0] | (dataCombined[1] << 8) | (dataCombined[2] << 16);
                        testDict.Add(key, value);
                    }
                    dataBase += xIncr;
                    dataDetail += xIncr;
                    dataCombined += xIncr;
                }
            }
            combineStopwatch.Stop();
            
            combinedBitmap.UnlockBits(bDataCombined);
            image2.UnlockBits(bData1);
            image1.UnlockBits(bData1);
            //combinedBitmap.Save("helloyou.png", ImageFormat.Png);
            testDict.Clear();
            Console.Write(combineStopwatch.ElapsedMilliseconds + "\n");
        }
