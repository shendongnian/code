    public class WebBrowserHook
    {
        private bool _isNavigating = false;
        private bool _isLoading = false;
        private bool _isLoaded = false;
        private WebBrowser _webBrowser = null;
        public WebBrowserHook(WebBrowser webBrowser)
        {
            _webBrowser = webBrowser;
            
            _webBrowser.Loaded += (s, e) =>
            {
                try
                {
                    var axWebBrowser = (SHDocVw.WebBrowser)GetActiveXInstance(this._webBrowser);
                    axWebBrowser.DownloadBegin += delegate
                    {
                        HandleDownloadActivity();
                    };
                    axWebBrowser.NavigateComplete2 += delegate(object pDisp, ref object URL)
                    {
                        // top frame?
                        if (Object.ReferenceEquals(axWebBrowser, pDisp))
                        {
                            this._isNavigating = true;
                            HandleDownloadActivity();
                        }
                    };
                }
                catch (Exception ex)
                {
                    AppLog.LogException(ex);
                }
            };
        }
        public event EventHandler Navigated;
        public event EventHandler Refreshed;
        public WebBrowser Browser
        {
            get{return _webBrowser;}
        }
        // handler for document.readyState == "complete"
        private void DomDocumentCompleteHandler(mshtml.HTMLDocument domDocument)
        {
            try
            {
                mshtml.HTMLWindow2 domWindow = (mshtml.HTMLWindow2)domDocument.parentWindow;
                domWindow.attachEvent("onunload", new DomEventHandler(delegate
                {
                    this._isLoaded = false;
                    this._isLoading = false;
                }));
                var navigated = this._isNavigating;
                this._isNavigating = false;
                this._isLoaded = true;
                this._isLoading = false;
                if (navigated)
                {
                    if (Navigated != null)
                        Navigated(this, new EventArgs());
                }
                else
                {
                    if (Refreshed != null)
                        Refreshed(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                AppLog.LogException(ex);
            }
        }
        private void HandleDownloadActivity()
        {
            try
            {
                mshtml.HTMLDocument domDocument = (mshtml.HTMLDocument)this._webBrowser.Document;
                if (domDocument == null)
                    return;
                if (_isLoading || _isLoaded)
                    return;
                this._isLoading = true;
                if (domDocument.readyState == "complete")
                {
                    DomDocumentCompleteHandler(domDocument);
                }
                else
                {
                    DomEventHandler handler = null;
                    handler = new DomEventHandler(delegate
                    {
                        if (domDocument.readyState == "complete")
                        {
                            domDocument.detachEvent("onreadystatechange", handler);
                            DomDocumentCompleteHandler(domDocument);
                        }
                    });
                    domDocument.attachEvent("onreadystatechange", handler);
                }
            }
            catch (Exception ex)
            {
                AppLog.LogException(ex);
            }
        }
        /// <summary>
        /// Get the underlying WebBrowser ActiveX object;
        /// this code depends on SHDocVw.dll COM interop assembly,
        /// generate SHDocVw.dll: "tlbimp.exe ieframe.dll",
        /// and add as a reference to the project
        /// </summary>
        private static object GetActiveXInstance(WebBrowser wb)
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
    }
