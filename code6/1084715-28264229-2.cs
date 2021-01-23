    HtmlElementCollection classButton = webBrowser1.Document.GetElementsByTagName("input"); 
    foreach (HtmlElement element in classButton)
    {
        var value = element.GetAttribute("value");
        if (value.Trim().ToLower().Equals("ذخيره يا چاپ"))
            {
               element.InvokeMember("click");
            }
    }
