    HtmlElementCollection col = webBrowser1.Document.GetElementsByTagName("input");
    foreach (HtmlElement element in col)
            {
                if (element.GetAttribute("name").Equals("username"))
                {                   
                    element.SetAttribute("value", "xyz");
                }
             }
