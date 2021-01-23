    HtmlElement selectF8 = webBrowser1.Document.GetElementById("F8");
    foreach (HtmlElement item in selectF8.Children)
    {
        if (item.GetAttribute("value") == webBrowser1.Document.GetElementById("F8").GetAttribute("value"))
        {
            assigneeText.Text = item.InnerText;
        }
    }
