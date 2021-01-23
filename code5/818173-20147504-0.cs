    public class OutputRecorder : AVCaptureVideoDataOutputSampleBufferDelegate 
    {   
        public override void DidOutputSampleBuffer (AVCaptureOutput captureOutput, CMSampleBuffer sampleBuffer, AVCaptureConnection connection)
        {
            try 
            {
                using (var pixelBuffer = sampleBuffer.GetImageBuffer () as CVPixelBuffer)
                {
                    pixelBuffer.Lock (0);
                    CVPixelFormatType ft = pixelBuffer.PixelFormatType;
                    var baseAddress = pixelBuffer.BaseAddress;
                    int bytesPerRow = pixelBuffer.BytesPerRow;
                    int width = pixelBuffer.Width;
                    int height = pixelBuffer.Height;
                    byte [] managedArray = new byte[width * height];
                    Marshal.Copy(baseAddress, managedArray, 0, width * height);
                    byte [] rawResult = new byte[3000];
                    int resLength = BarcodeScannerClass.MWB_scanGrayscaleImage(managedArray,width,height,out rawResult);
                    pixelBuffer.Unlock (0);
