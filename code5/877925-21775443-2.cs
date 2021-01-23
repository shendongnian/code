    public class BrowserExtendedNavigatingEventArgs : CancelEventArgs
    {
        // ...
        public bool IsInsideFrame
        {
            get
            {
                var wb = AutomationObject as UnsafeNativeMethods.IWebBrowser2;
                return wb != null && wb.Parent != null;
            }
        }
        // ...
    }
