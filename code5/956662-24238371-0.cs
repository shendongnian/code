    public static HtmlElement GetHTMLElementByClass(HtmlDocument document, String className)
    {
        foreach (HtmlElement element in document.All)
        {
            if (element.GetAttribute("className") == className)
            {
                return element;
            }
        }
    }
