    `HtmlElement hleGetData = (HtmlElement)hdoc.GetElementById("getButton");
    hleGetData.InvokeMember("click");
    while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
    {
        System.Windows.Forms.Application.DoEvents();
    };
    //Some DoEvents....
    System.Windows.Forms.Application.DoEvents();
    System.Windows.Forms.Application.DoEvents();
    System.Windows.Forms.Application.DoEvents();
    System.Windows.Forms.Application.DoEvents();
    System.Windows.Forms.Application.DoEvents();`
