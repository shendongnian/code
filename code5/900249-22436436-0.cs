    HtmlElementCollection tagsColl=webBrowser1.Document.GetElementsByTagName("input");
    foreach (HtmlElement currentTag in tagsColl)
    {
        if (currentTag.Name.Equals("email"))
            currentTag.SetAttribute("value", username);
    
        if (currentTag.Name.Equals("password"))
            currentTag.SetAttribute("value", password);
    }
    HtmlElement button = webBrowser1.Document.GetElementById("submit");
    if (button) button.InvokeMember("click");
