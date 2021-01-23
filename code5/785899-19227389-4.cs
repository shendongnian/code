    private void InvokeTestMethod(DateTime date)
    {
        if (webBrowser1.Document != null)
        {
            webBrowser1.Document.InvokeScript("eval", (Object)"(function() { window.newDate=new Date('03 Oct 2013 16:04:19'); })()";);
            webBrowser1.Document.InvokeScript("alert", (Object)"(function() { return window.newDate; })()");
        }
    }
    private void Test()
    {
        InvokeTestMethod(DateTime.Now);
    }
