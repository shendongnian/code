        private void ChangeTransparency(ref WriteableBitmap bmp, int newAlpha = 127)
        {
            try
            {
                int width = bmp.PixelWidth;
                int height = bmp.PixelHeight;
                int stride = bmp.BackBufferStride;
                int bytesPerPixel = (bmp.Format.BitsPerPixel + 7) / 8;
                unsafe
                {
                    bmp.Lock();
                    byte* pImgData = (byte*)bmp.BackBuffer;
                    int cRowStart = 0;
                    int cColStart = 0;
                    for (int row = 0; row < height; row++)
                    {
                        cColStart = cRowStart;
                        for (int col = 0; col < width; col++)
                        {
                            // the RGB values are pre-multiplied by the alpha in a Pbgra32 bitmap
                            // so I need to un-pre-multiply them with the current alpha
                            // and then re-pre-multiply them by the new alpha
                            byte* bPixel = pImgData + cColStart;
                            
                            byte A = bPixel[3];
                            if (A > 0)
                            {
                                byte B = bPixel[0];
                                byte G = bPixel[1];
                                byte R = bPixel[2];
                                bPixel[0] = Convert.ToByte((B/A)*newAlpha);
                                bPixel[1] = Convert.ToByte((G/A)*newAlpha);
                                bPixel[2] = Convert.ToByte((R/A)*newAlpha);
                                bPixel[3] = Convert.ToByte(newAlpha);
                            }
                            cColStart += bytesPerPixel;
                        }
                        cRowStart += stride;
                    }
                    bmp.Unlock();
                }
            }
            catch (Exception ex)
            {
                
            }
        }
