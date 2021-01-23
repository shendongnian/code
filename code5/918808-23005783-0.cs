    public unsafe void LoadImage(ushort[] depthImage, byte[] rgbImage, int[] size)
    {
        unsafe
        {
            fixed (int* pSize = _im.nSize)
            fixed (ushort* pDepth = depthImage)
            fixed (byte* pRGB = rgbImage)
            fixed (S_IMAGE* pim = &_im)
            {
                pSize[0] = size[0];
                pSize[1] = size[1];
                _im.pColorIm = pRGB;
                _im.pDepthIm = pDepth;
            }
        }
    }
