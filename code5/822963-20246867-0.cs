    public byte[] ColorImageFrameData
    {
        get
        {
            byte[] ret= new byte[_colorImageFrame.PixelDataLength]; 
            _colorImageFrame.CopyPixelDataTo(ret);
            return ret;
        }
    }
