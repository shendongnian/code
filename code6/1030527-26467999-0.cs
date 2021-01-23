    public static IEnumerable<HtmlElement> Descendants(this HtmlElement root)
    {
        return root.Children
            .Cast<HtmlElement>()
            .SelectMany(x => Descendants(x));
    }
