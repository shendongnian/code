    private void InvokeTestMethod(DateTime date)
    {
        if (webBrowser1.Document != null)
        {
            Object[] args = new Object[2];
            objArray[0] = (Object)date;
            webBrowser1.Document.InvokeScript("test", args);
        }
    }
    private void Test()
    {
        InvokeTestMethod(DateTime.Now);
    }
