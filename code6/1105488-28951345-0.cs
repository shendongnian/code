        void preview(Bitmap bm, int i)
        {
            BitmapData bmData = bm.LockBits(new Rectangle(0,0,bm.Width,bm.Height), ImageLockMode.ReadWrite, bm.PixelFormat);
            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;
            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                int nOffset = stride - bm.Width * 3;
                int nWidth = bm.Width * 3;
                for (int y = 0; y < bm.Height; ++y)
                {
                    for (int x = 0; x < bm.Width; ++x)
                    {
                        switch (i)
                        {
                            case 0:
                                {
                                    p[0] = (byte)0;
                                    p[1] = (byte)0;
                                    break;
                                }
                            case 1:
                                {
                                    p[0] = (byte)0;
                                    p[2] = (byte)0;
                                    break;
                                }
                            default:
                                {
                                    p[1] = (byte)0;
                                    p[2] = (byte)0;
                                    break;
                                }                               
                        }
                        p+=3;
                    }
                    p += nOffset;
                }
            }
            bm.UnlockBits(bmData);
        }
