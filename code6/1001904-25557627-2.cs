    public static void FillField(object doc, string id, string value)
    {
        var element = findElementByID(doc, id);
        element.setAttribute("value", value);
    }
    public static void ClickButton(object doc, string id)
    {
        var element = findElementByID(doc, id);
        element.click();
    }
    private static IHTMLElement findElementByID(object doc, string id)
    {
        IHTMLDocument2 thisDoc;
        if (!(doc is IHTMLDocument2))
            return null;
        else
            thisDoc = (IHTMLDocument2)doc;
        
        var element = thisDoc.all.OfType<IHTMLElement>()
            .Where(n => n != null && n.id != null)
            .Where(e => e.id == id).First();
        return element;
    }
