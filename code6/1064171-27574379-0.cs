    public partial class MainWindow : Window
    {
       public MainWindow()
       {
          InitializeComponent();
          this.ResizeMode = ResizeMode.NoResize;
          this.WindowStyle = WindowStyle.ToolWindow;
          this.WindowState = WindowState.Maximized;
          this.Topmost = true;
          this.PreviewKeyDown +=
              (s, e) =>
              {
                 if (e.Key == Key.F11)
                 {
                    if (this.WindowStyle != WindowStyle.SingleBorderWindow)
                    {
                       this.ResizeMode = ResizeMode.CanResize;
                       this.WindowStyle = WindowStyle.SingleBorderWindow;
                       this.WindowState = WindowState.Normal;
                       this.Topmost = false;
                    }
                    else
                    {
                       this.ResizeMode = ResizeMode.NoResize;
                       this.WindowStyle = WindowStyle.ToolWindow;
                       this.WindowState = WindowState.Maximized;
                       this.Topmost = true;
                    }
                 }
              };
       }
    }
