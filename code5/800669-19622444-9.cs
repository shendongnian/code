    public void getFrameFromWebcam()
    {
       if (iPtr != IntPtr.Zero)
       {
           Marshal.FreeCoTaskMem(iPtr);
           iPtr = IntPtr.Zero;
       }
            //Get Image
            iPtr = sampleGrabberCallBack.getFrame();
            Bitmap bitmapOfFrame = new Bitmap(sampleGrabberCallBack.width, sampleGrabberCallBack.height, sampleGrabberCallBack.capturePitch, PixelFormat.Format24bppRgb, iPtr);
            bitmapOfFrame.RotateFlip(RotateFlipType.RotateNoneFlipY);
            barcodeReader(bitmapOfFrame);
    }
