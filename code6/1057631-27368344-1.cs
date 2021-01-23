    //in chrome
    try
    {
        HtmlDocument doc = webBrowser1.Document;
        HtmlElement submit = doc.GetElementById("btnEntryAddSav");
        submit.InvokeMember("click");
    }
    catch { }
    //in IE try to find name tag and:
    try
    {
        HtmlElementCollection Bpic = webBrowser1.Document.GetElementsByTagName("input");
        foreach (HtmlElement bp in Bpic) {
            string name = bp.Name;
            if (name == "input_name")
                bp.InvokeMember("click");
        }
    }
    catch{}
