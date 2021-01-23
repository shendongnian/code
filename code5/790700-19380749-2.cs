    using Microsoft.Win32;
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfWebBrowser
    {
        public partial class MainWindow : Window
        {
            bool navigating = false;
            bool loading = false;
            bool loaded = false;
    
            public MainWindow()
            {
                SetBrowserFeatureControl();
                InitializeComponent();
    
                this.Loaded += (s, e) =>
                {
                    var axWebBrowser = (SHDocVw.WebBrowser)GetActiveXInstance(this.webBrowser);
    
                    axWebBrowser.DownloadBegin += delegate
                    {
                        HandleDownloadActivity();
                    };
    
                    axWebBrowser.NavigateComplete2 += delegate(object pDisp, ref object URL)
                    {
                        // top frame?
                        if (Object.ReferenceEquals(axWebBrowser, pDisp))
                        {
                            this.navigating = true;
                            HandleDownloadActivity();
                        }
                    };
    
                    this.webBrowser.Navigate("http://example.com");
                };
            }
    
            // handler for document.readyState == "complete"
            void DomDocumetCompleteHandler(dynamic domDocument)
            {
                dynamic domWindow = domDocument.parentWindow;
    
                domWindow.attachEvent("onunload", new DomEventHandler(delegate
                {
                    this.loaded = false;
                    this.loading = false;
                }));
    
                var navigated = this.navigating;
    
                this.navigating = false;
                this.loaded = true;
                this.loading = false;
    
                MessageBox.Show(navigated ? "Navigated" : "Refreshed");
            }
    
            void HandleDownloadActivity()
            {
                dynamic domDocument = this.webBrowser.Document;
                if (domDocument == null)
                    return;
    
                if (loading || loaded)
                    return;
    
                this.loading = true;
    
                if (domDocument.readyState == "complete")
                {
                    DomDocumetCompleteHandler(domDocument);
                }
                else
                {
                    DomEventHandler handler = null;
                    handler = new DomEventHandler(delegate
                    {
                        if (domDocument.readyState == "complete")
                        {
                            domDocument.detachEvent("onreadystatechange", handler);
                            DomDocumetCompleteHandler(domDocument);
                        }
                    });
                    domDocument.attachEvent("onreadystatechange", handler);
                }
            }
    
            /// <summary>
            /// Get the underlying WebBrowser ActiveX object;
            /// this code depends on SHDocVw.dll COM interop assembly,
            /// generate SHDocVw.dll: "tlbimp.exe ieframe.dll",
            /// and add as a reference to the project
            /// </summary>
            static object GetActiveXInstance(WebBrowser wb)
            {
                return wb.GetType().InvokeMember("ActiveXInstance",
                    BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, wb, new object[] { }) as SHDocVw.WebBrowser;
            }
    
            /// <summary>
            /// EventHandler - adaptor to call C# back from JavaScript or DOM event handlers
            /// </summary>
            [ComVisible(true), ClassInterface(ClassInterfaceType.AutoDispatch)]
            public class DomEventHandler
            {
                [ComVisible(false)]
                public delegate void Callback(ref object result, object[] args);
    
                [ComVisible(false)]
                private Callback _callback;
    
                [DispId(0)]
                public object Method(params object[] args)
                {
                    var result = Type.Missing; // Type.Missing is "undefined" in JavaScript
                    _callback(ref result, args);
                    return result;
                }
    
                public DomEventHandler(Callback callback)
                {
                    _callback = callback;
                }
            }
    
            /// <summary>
            /// WebBrowser version control
            /// http://msdn.microsoft.com/en-us/library/ee330730(v=vs.85).aspx#browser_emulation
            /// </summary>
            void SetBrowserFeatureControl()
            {
                // http://msdn.microsoft.com/en-us/library/ee330720(v=vs.85).aspx
    
                // FeatureControl settings are per-process
                var fileName = System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
    
                // make the control is not running inside Visual Studio Designer
                if (String.Compare(fileName, "devenv.exe", true) == 0 || String.Compare(fileName, "XDesProc.exe", true) == 0)
                    return;
    
                // Webpages containing standards-based !DOCTYPE directives are displayed in IE9/IE10 Standards mode.
                SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, 9000);
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
    
        }
    }
