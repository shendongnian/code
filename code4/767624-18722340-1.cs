    public MainWindow() {
      InitializeComponent();
      Loaded += OnLoaded;
    }
    
    private void OnLoaded(object sender, RoutedEventArgs routedEventArgs) {
      WindowState = WindowState.Maximized;
      ResizeMode = ResizeMode.NoResize;
      ShowMaxRestoreButton = false;
      ShowMinButton = false;
      Loaded -= OnLoaded;
    }
