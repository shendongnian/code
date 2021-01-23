    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                CefSharp.CefSettings settings = new CefSharp.CefSettings();
                settings.CachePath = System.IO.Directory.GetCurrentDirectory();            
                CefSharp.Cef.Initialize(settings);
    
                InitializeComponent();
                //webcontrol.BrowserSettings.ApplicationCache = CefSharp.CefState.Enabled;
    
            }
        }
