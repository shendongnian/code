	namespace Basic_CameraViewer
	{
		public partial class MainWindow : Window
		{
			private VideoViewerWPF _videoViewerWpf;
			private BitmapSourceProvider _provider;
			private IIPCamera _ipCamera;
			private WebCamera _webCamera;
			private MediaConnector _connector;
			private MPEG4Recorder _recorder;
			private IVideoSender _videoSender;
			public MainWindow()
			{
				InitializeComponent();
				_connector = new MediaConnector();
				_provider = new BitmapSourceProvider();
				SetVideoViewer();
			}
			private void SetVideoViewer()
			{
				_videoViewerWpf = new VideoViewerWPF
				{
					HorizontalAlignment = HorizontalAlignment.Stretch,
					VerticalAlignment = VerticalAlignment.Stretch,
					Background = Brushes.Black
				};
				CameraBox.Children.Add(_videoViewerWpf);
				_videoViewerWpf.SetImageProvider(_provider);
			}
			private void ConnectIPCamera_Click(object sender, RoutedEventArgs e)
			{
				var host = HostTextBox.Text;
				var user = UserTextBox.Text;
				var pass = Password.Password;
				_ipCamera = IPCameraFactory.GetCamera(host, user, pass);
				if (_ipCamera == null) return;
				_connector.Connect(_ipCamera.VideoChannel, _provider);
				_videoSender = _ipCamera.VideoChannel;
				_ipCamera.Start();
				_videoViewerWpf.Start();
			}
			private void DisconnectIPCamera_Click(object sender, RoutedEventArgs e)
			{
				_videoViewerWpf.Stop();
				_ipCamera.Disconnect();
				_ipCamera.Dispose();
				_connector.Disconnect(_ipCamera.VideoChannel, _provider);
			}
			private void StartCapture_Click(object sender, RoutedEventArgs e)
			{
				if (_videoSender == null) return;
				var date = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" +
							DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
				var currentpath = AppDomain.CurrentDomain.BaseDirectory + date + ".mpeg4";
				_recorder = new MPEG4Recorder(currentpath);
				_recorder.MultiplexFinished += _recorder_MultiplexFinished;
				_connector.Connect(_videoSender, _recorder.VideoRecorder);
			}
			void _recorder_MultiplexFinished(object sender, Ozeki.VoIP.VoIPEventArgs<bool> e)
			{
				_recorder.MultiplexFinished -= _recorder_MultiplexFinished;
				_recorder.Dispose();
			}
			private void StopCapture_Click(object sender, RoutedEventArgs e)
			{
				if (_videoSender == null) return;
				_connector.Disconnect(_videoSender, _recorder.VideoRecorder);
				_recorder.Multiplex();
			}
		}
	}
