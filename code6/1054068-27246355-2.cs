        private static Bitmap GetAHE_BMP_advanced(int halfblocksize, Size sourceBmpSize, int[,,] sourceBmpData)
        {
            const int m = 256;
            const int n = 3;
            //adaptive histogram equalization
            Size imgsz = sourceBmpSize;
            //compute total number of pixels
            double totalNum = imgsz.Height * imgsz.Width;
            var colors = new Color[sourceBmpSize.Width, sourceBmpSize.Height];
            for (int i = 0; i < imgsz.Height; i++)
            {
                for (int j = 0; j < imgsz.Width; j++)
                {
                    double[,] prob = new double[m, n];
                    int[,] mapping = new int[m, n];
                    //produce ahe for this pixel:
                    for (int u = i - halfblocksize; u <= i + halfblocksize; u++)
                    {
                        for (int v = j - halfblocksize; v <= j + halfblocksize; v++)
                        {
                            int hi = u;
                            int wi = v;
                            //mirror:
                            if (hi < 0) hi = -hi;
                            else if (hi >= imgsz.Height)
                                hi = 2 * (imgsz.Height - 1) - hi;
                            if (wi < 0) wi = -wi;
                            else if (wi >= imgsz.Width)
                                wi = 2 * (imgsz.Width - 1) - wi;
                            //get hist
                            prob[sourceBmpData[wi, hi, 0], 0] += 1;
                            prob[sourceBmpData[wi, hi, 1], 1] += 1;
                            prob[sourceBmpData[wi, hi, 2], 2] += 1;
                        }
                    }
                    double[] probSum = new double[n];
                    for (int k = 0; k < m; k++)
                    {
                        prob[k, 0] /= totalNum;
                        prob[k, 1] /= totalNum;
                        prob[k, 2] /= totalNum;
                        //Sum
                        probSum[0] += prob[k, 0];
                        probSum[1] += prob[k, 1];
                        probSum[2] += prob[k, 2];
                        if (i == 40 && j == 40) //mapping(INT32)
                        {
                            mapping[k, 0] = Convert.ToInt32(255.0 * probSum[0]);
                            mapping[k, 1] = Convert.ToInt32(255.0 * probSum[1]);
                            mapping[k, 2] = Convert.ToInt32(255.0 * probSum[2]);
                        }
                    }
                    colors[i, j] = Color.FromArgb(mapping[sourceBmpData[j, i, 0], 0],
                                                  mapping[sourceBmpData[j, i, 1], 1],
                                                  mapping[sourceBmpData[j, i, 2], 2]);
                }
            }
            return BitmapHelper.CreateBitmap(colors);
        }
