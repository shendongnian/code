    public HtmlControl child()
    {
        HtmlControl parent = new HtmlControl(browser);
        parent.SearchProperties["id"] = "[my id]";
        HtmlControl child = new HtmlControl(parent);
        child.SearchProperties["innerText"] = "[the inner text]";
        return child;
    }
