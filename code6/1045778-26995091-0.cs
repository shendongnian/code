    Method(HtmlElement Element)
    {
      MessageBox.Show(Element.InnerText);
    
      WebBrowser WebBrowser = new WebBrowser();
    
      WebBrowser.DocumentText = "<html><head></head><body>" + Element.OuterHtml + "</body></html>";
    
      while (WebBrowserReadyState.Complete != WebBrowser.ReadyState)
                Application.DoEvents();
    
      MessageBox.Show(WebBrowser.Document.Body.InnerText);
    }
