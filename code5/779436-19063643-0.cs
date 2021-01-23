    using Microsoft.Win32;
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WebAutomation
    {
        // http://stackoverflow.com/q/19044659/1768303
    
        public partial class MainForm : Form
        {
            WebBrowser wb;
    
            // async navigation support
            TaskCompletionSource<bool> onloadTcs;
            bool documentCompleted;
    
            // non-deterministic delay to let AJAX code run
            const int AJAX_DELAY = 1000; 
    
            // keep track of the main automation task
            CancellationTokenSource mainCts; 
            Task mainTask = null;
    
            public MainForm()
            {
                SetBrowserFeatureControl(); // set FEATURE_BROWSER_EMULATION first
    
                InitializeComponent();
                
                InitBrowser(); 
    
                this.Load += (s, e) => 
                {
                    // start the automation when form is loaded
                    // timeout the whole automation task in 30s
                    mainCts = new CancellationTokenSource(30000); 
                    mainTask = DoAutomationAsync(mainCts.Token);
                };
    
                this.FormClosing += (s, e) => 
                {
                    // cancel the automation if form closes
                    if (this.mainTask != null && !this.mainTask.IsCompleted)
                        mainCts.Cancel(); 
                };
            }
    
            // the main automation logic
            async Task DoAutomationAsync(CancellationToken ct)
            {
                await NavigateAsync(ct, () => NavigateAction("http://localhost:81/test.html"), 10000); // timeout in 10s
    
                // do the DOM automation
                HtmlElementCollection all = wb.Document.GetElementsByTagName("button");
                // throw if none or more than one element found
                HtmlElement btn = all.Cast<HtmlElement>().Single(
                    el => el.InnerHtml == "ACCEPT the terms of use");
    
                // simulate a click which causes navigation
                await NavigateAsync(ct, () => btn.InvokeMember("click"), 10000); // timeout in 10s
    
                // form submitted and new page loaded, log the page's HTML
                string html = ((dynamic)this.wb.Document.DomDocument).documentElement.outerHTML;
                Trace.Write(html);
    
                // could continue with another NavigateAsync
                // othrwise, the automation completed
            }
    
            // create a WebBrowser instance (could use an existing one)
            // and initialize event handlers
            void InitBrowser()
            {
                this.wb = new WebBrowser();
                this.wb.Dock = DockStyle.Fill;
                this.Controls.Add(this.wb);
                this.wb.Visible = true;
    
                this.onloadTcs = null;
                this.documentCompleted = false;
    
                this.wb.DocumentCompleted += delegate
                {
                    // DocumentCompleted may be called several time for the same page,
                    // beacuse of frames
                    if (documentCompleted || this.onloadTcs == null || this.onloadTcs.Task.IsCanceled)
                        return; 
                    documentCompleted = true;
                    // handle DOM onload event to make sure the document is fully loaded
                    this.wb.Document.Window.AttachEventHandler("onload",
                        (s, e) => onloadTcs.TrySetResult(true));
                };
            }
    
            // asynchronous navigation
            async Task NavigateAsync(CancellationToken ct, Action startNavigation, int timeout = Timeout.Infinite)
            {
                this.documentCompleted = false;
                this.onloadTcs = new TaskCompletionSource<bool>();
    
                CancellationTokenSource cts;
                if (timeout != Timeout.Infinite)
                    cts = CancellationTokenSource.CreateLinkedTokenSource(new CancellationTokenSource(timeout).Token, ct);
                else 
                    cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
                
                cts.Token.Register(() => this.onloadTcs.TrySetCanceled(), useSynchronizationContext: true);
                startNavigation();
    
                // wait for DOM onload, throw if cancelled
                await this.onloadTcs.Task;
                // non-deterministic wait for AJAX dynamic code, throw if cancelled
                await Task.Delay(AJAX_DELAY, cts.Token);
                
                cts.Dispose();
            }
    
            // helpers
    
            void NavigateAction(string url)
            {
                this.wb.Navigate(url);
            }
    
            void SetBrowserFeatureControl()
            {
                // http://msdn.microsoft.com/en-us/library/ee330720(v=vs.85).aspx
    
                // FeatureControl settings are per-process
                var fileName = System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
    
                // make the control is not running inside Visual Studio Designer
                if (String.Compare(fileName, "devenv.exe", true) == 0 || String.Compare(fileName, "XDesProc.exe", true) == 0)
                    return;
    
                SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, GetBrowserEmulationMode()); // Webpages containing standards-based !DOCTYPE directives are displayed in IE10 Standards mode.
            }
    
            void SetBrowserFeatureControlKey(string feature, string appName, uint value)
            {
                using (var key = Registry.CurrentUser.CreateSubKey(
                    String.Concat(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\", feature),
                    RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    key.SetValue(appName, (UInt32)value, RegistryValueKind.DWord);
                }
            }
    
            UInt32 GetBrowserEmulationMode()
            {
                int browserVersion = 7;
                using (var ieKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer",
                    RegistryKeyPermissionCheck.ReadSubTree,
                    System.Security.AccessControl.RegistryRights.QueryValues))
                {
                    var version = ieKey.GetValue("svcVersion");
                    if (null == version)
                    {
                        version = ieKey.GetValue("Version");
                        if (null == version)
                            throw new ApplicationException("Microsoft Internet Explorer is required!");
                    }
                    int.TryParse(version.ToString().Split('.')[0], out browserVersion);
                }
    
                UInt32 mode = 10000; // Internet Explorer 10. Webpages containing standards-based !DOCTYPE directives are displayed in IE10 Standards mode. Default value for Internet Explorer 10.
                switch (browserVersion)
                {
                    case 7:
                        mode = 7000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode. Default value for applications hosting the WebBrowser Control.
                        break;
                    case 8:
                        mode = 8000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode. Default value for Internet Explorer 8
                        break;
                    case 9:
                        mode = 9000; // Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode. Default value for Internet Explorer 9.
                        break;
                    default:
                        // use IE10 mode by default
                        break;
                }
    
                return mode;
            }
        }
    }
