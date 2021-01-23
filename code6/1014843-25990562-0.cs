    string content = null;
    var iframe = browser.Document.GetElementsByTagName("iframe").FirstOrDefault() as Gecko.DOM.GeckoIFrameElement;
    if (iframe != null)
    {
        var html = iframe.ContentDocument.DocumentElement as GeckoHtmlElement;
        if (html != null)
            content = html.OuterHtml;
        textBox1.Text = content;
        GeckoElementCollection elements = iframe.ContentDocument.GetElementsByName("username");
        foreach (var element in elements)
        {
            GeckoInputElement input = (GeckoInputElement)element;
            input.Value = "Auto filled!";
        }
    }
