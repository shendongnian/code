    this.webBrowser.ObjectForScripting = new ObjectForScripting(this.webBrowser);
    // ...
    [ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    public class ObjectForScripting :
        System.Reflection.IReflect
    {
        WebBrowser _browser;
        SynchronizationContext _context = SynchronizationContext.Current;
        public ObjectForScripting(WebBrowser browser)
        {
            _browser = browser;
        }
        public void TestMethod()
        {
            _context.Post(_ =>
            {
                _browser.Document.InvokeScript("alert", new object[] { 
                    "Process a call from JavaScript asynchronosuly." });
            }, null);
        }
    }
