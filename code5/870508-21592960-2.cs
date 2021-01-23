    if (webBrowser1.ReadyState == System.Windows.Forms.WebBrowserReadyState.Complete)
    {
        System.Threading.Thread.Sleep(100);
        System.Windows.Forms.Application.DoEvents();
        btnOK.InvokeMember("click"); //Go back to Select Date for TimeSheet...Original Url...
    }
