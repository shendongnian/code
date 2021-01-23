    void webBrowser1_Navigating (object sender, WebBrowserNavigatingEventArgs e)
        {
            foreach (HtmlElement x in ((WebBrowser)sender).Document.GetElementsByTagName("script"))
            {
                if (x.OuterHtml.Contains("survey"))
                    e.Cancel = true;
            }
            foreach (HtmlElement x in ((WebBrowser)sender).Document.GetElementsByTagName("iframe"))
            {
                e.Cancel = true;
            }
            
        }  
