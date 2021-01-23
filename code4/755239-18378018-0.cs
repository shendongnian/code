    public class ScreenCaptureEventArgs : EventArgs
    {
        public ScreenCaptureEventArgs(ScreenCapture c)
        {
            Capture = c;
        }
 
        public ScreenCapture Capture { get; private set; }
    }
    public event EventHandler<ScreenCaptureEventArgs> ScreenCaptured;
