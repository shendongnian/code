    private readonly DispatcherTimer _timer;
    private PhotoCameraLuminanceSource _luminance;
    private QRCodeReader _reader;
    private PhotoCamera _photoCamera;
    
    //Constructor
    public ScanPage()
    {
        InitializeComponent();
    
        _timer = new DispatcherTimer();
        _timer.Interval = TimeSpan.FromMilliseconds(250);
        _timer.Tick += (o, arg) => ScanPreviewBuffer();
    }
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        _photoCamera = new PhotoCamera();
        _photoCamera.Initialized += OnPhotoCameraInitialized;
        _previewVideo.SetSource(_photoCamera);
    
        CameraButtons.ShutterKeyHalfPressed += (o, arg) => _photoCamera.Focus();
    
        base.OnNavigatedTo(e);
    }
    
    private void OnPhotoCameraInitialized(object sender, CameraOperationCompletedEventArgs e)
    {
        int width = Convert.ToInt32(_photoCamera.PreviewResolution.Width);
        int height = Convert.ToInt32(_photoCamera.PreviewResolution.Height);
    
        _luminance = new PhotoCameraLuminanceSource(width, height);
        _reader = new QRCodeReader();
    
        Dispatcher.BeginInvoke(() =>
        {
            _previewTransform.Rotation = _photoCamera.Orientation;
            _timer.Start();
        });
    }
    
    private void ScanPreviewBuffer()
    {
        try
        {
            _photoCamera.GetPreviewBufferY(_luminance.PreviewBufferY);
            var binarizer = new HybridBinarizer(_luminance);
            var binBitmap = new BinaryBitmap(binarizer);
            var result = _reader.decode(binBitmap);
            Dispatcher.BeginInvoke(() => MessageBox.Show(result.Text));
        }
        catch
        {
        }
    }
