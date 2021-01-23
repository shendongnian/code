    public class CameraServiceClass
    {
        VideoCaptureDevice videoSource;
        // CONSTRUTOR
        public void Start() {
            var videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            
            videoSource.Start();
        }
        private void video_NewFrame (object sender, NewFrameEventArgs eventArgs) {
            System.Drawing.Bitmap bmp = (System.Drawing.Bitmap)eventArgs.Frame.Clone();
            OnNovoFrame(new NovoFrameArgs(bmp));
        }
        public event NovoFrameEventHandler NovoFrame;
        protected void OnNovoFrame(NovoFrameArgs e) {
            if (NovoFrame != null)
                NovoFrame(this, e);
        }
    }
    public delegate void NovoFrameEventHandler(object sender, NovoFrameArgs e);
    public class NovoFrameArgs : EventArgs {
        System.Drawing.Bitmap _frame;
        public NovoFrameArgs(System.Drawing.Bitmap fr) {
            this._frame = fr;
        }
        public System.Drawing.Bitmap Frame {
            get { return _frame; }
            set { _frame = value; }
        }
    }
