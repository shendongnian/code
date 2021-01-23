    public partial class MainWindow : Window {
      public MainWindow() {
        InitializeComponent();
        this.SourceInitialized += MainWindow_SourceInitialized;
        this.KeyDown += MainWindow_KeyDown;
      }
      void MainWindow_KeyDown(object sender, KeyEventArgs e) {
        if (e.Key == Key.Escape) this.Close();
      }
      void MainWindow_SourceInitialized(object sender, EventArgs e) {
        var helper = new WindowInteropHelper(this);
        var hwnd = helper.Handle;
        var src = HwndSource.FromHwnd(hwnd);
        src.CompositionTarget.BackgroundColor = Colors.Transparent;
        WindowChrome.SetWindowChrome(this, new WindowChrome {
          CaptionHeight = 500,
          CornerRadius = new CornerRadius(0),
          GlassFrameThickness = new Thickness(0),
          NonClientFrameEdges = NonClientFrameEdges.None,
          ResizeBorderThickness = new Thickness(0),
          UseAeroCaptionButtons = false
        });
        GraphicsPath path = new GraphicsPath(FillMode.Alternate);
        path.StartFigure();
        path.AddArc(new RectangleF(0, 0, 500, 500), 0, 360);
        path.CloseFigure();
        var dbb = new DwmBlurBehind(true);
        dbb.SetRegion(Graphics.FromHwnd(hwnd), new Region(path));
        DwmApi.DwmEnableBlurBehindWindow(hwnd, ref dbb);
      }
    }
