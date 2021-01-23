    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                CefSharp.CefSettings settings = new CefSharp.CefSettings();
                settings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\CEF"; 
               CefSharp.Cef.Initialize(settings);
    
                InitializeComponent();
                //webcontrol.BrowserSettings.ApplicationCache = CefSharp.CefState.Enabled;
    
            }
        }
