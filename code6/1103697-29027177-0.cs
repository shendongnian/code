    public partial class PrintWindow : Window
    {
        public PrintWindow()
        {
            InitializeComponent();
            webBrowser.Navigate("http://www.google.com");
        }
        // I have added a button to demonstrate
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // NOTE: this works only when the document as been loaded
            IOleServiceProvider sp = webBrowser.Document as IOleServiceProvider;
            if (sp != null)
            {
                Guid IID_IWebBrowserApp = new Guid("0002DF05-0000-0000-C000-000000000046");
                Guid IID_IWebBrowser2 = new Guid("D30C1661-CDAF-11d0-8A3E-00C04FC9E26E");
                const int OLECMDID_PRINT = 6;
                const int OLECMDEXECOPT_DONTPROMPTUSER = 2;
                dynamic wb; // will be of IWebBrowser2 type, but dynamic is cool
                sp.QueryService(IID_IWebBrowserApp, IID_IWebBrowser2, out wb);
                if (wb != null)
                {
                    // note: this will send to the default printer, if any
                    wb.ExecWB(OLECMDID_PRINT, OLECMDEXECOPT_DONTPROMPTUSER, null, null);
                }
            }
        }
        [ComImport, Guid("6D5140C1-7436-11CE-8034-00AA006009FA"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IOleServiceProvider
        {
            [PreserveSig]
            int QueryService([MarshalAs(UnmanagedType.LPStruct)] Guid guidService, [MarshalAs(UnmanagedType.LPStruct)]  Guid riid, [MarshalAs(UnmanagedType.IDispatch)] out object ppvObject);
        }
    }
