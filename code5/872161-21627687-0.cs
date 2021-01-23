	public MainWindow()
	{
		InitializeComponent();
		Loaded += OnLoaded;
	}
	private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
	{
		Loaded -= OnLoaded;
		var wnd = new ProgressWindow();
		var dispatcher = wnd.Dispatcher;
		Task.Factory.StartNew(() =>
		{
			using (var stream = new StreamReader("C:\\test.txt"))
				return stream.ReadToEnd();
		}).ContinueWith(x =>
		{
			//Main window dispatcher
			Dispatcher.Invoke(DispatcherPriority.Background, new Action(() => richTextBox1.AppendText(x.Result)));
			//progress window dispatcher
			dispatcher.Invoke(DispatcherPriority.DataBind, new Action(wnd.Close));
		});
		wnd.ShowDialog();
	}
