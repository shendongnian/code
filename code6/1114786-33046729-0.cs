    //Load page that will end up as the "Agreement" page
    WebBrowser webBrowser1 = new WebBrowser();
    webBrowser1.Navigate(url);
    while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
        System.Windows.Forms.Application.DoEvents();
    //submit agree button click
    webBrowser1.Document.GetElementById("agree_terms_use").InvokeMember("Click");
    webBrowser1.Document.Forms[1].InvokeMember("submit");
    //Navigate back to the page which should now allow access to the data
    WebBrowser webBrowser2 = new WebBrowser();
    webBrowser2.Navigate(url);
    while (webBrowser2.ReadyState != WebBrowserReadyState.Complete)
        System.Windows.Forms.Application.DoEvents();
    HtmlElement body = webBrowser2.Document.Body;
    string webResults = body.InnerHtml;
    webResults = webResults.Replace("<PRE>", "").Replace("</PRE>", "");
    webResults = webResults.Replace("&amp;", "&");
    StreamWriter file = File.CreateText(outputFile);
    file.Write(webResults);
    file.Close();
