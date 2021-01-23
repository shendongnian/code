    HtmlElementCollection classButton = webBrowser1.Document.GetElementsByTagName("input"); 
    foreach (HtmlElement element in classButton)
    {
        if (element.GetAttribute("value").Equals("ذخيره يا چاپ")
            {
               element.InvokeMember("click");
            }
    }
