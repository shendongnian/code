    var links = webBrowser1.Document.GetElementsByTagName("a");
    foreach (HtmlElement link in links)
    {
        if (link.InnerText == "Proceed anyway")
        {
            link.InvokeMember("click");
        }
    }
    // following is for the page that is loaded on click of link.
    var gwt_uid_126 = webBrowser1.Document.GetElementById("gwt-uid-126");
    if(gwt_uid_126 != null)
    {
        gwt_uid_126.InvokeMember("click");
    }
