    namespace WindowsFormApp
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                SetFeatureBrowserEmulation();
                InitializeComponent();
                this.webBrowser1.Navigate("http://instagram.com/p/lhG0xdE8B4/#");
            }
    
            private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                this.textBox1.Text = this.webBrowser1.Document.GetElementsByTagName("head")[0].OuterHtml;
            }
    
            static void SetFeatureBrowserEmulation()
            {
                if (LicenseManager.UsageMode != LicenseUsageMode.Runtime)
                    return;
                var appName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION",
                    appName, 9000, Microsoft.Win32.RegistryValueKind.DWord);
            }
        }
    }
