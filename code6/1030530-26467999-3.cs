    public static IEnumerable<HtmlElement> Descendants(this HtmlElement root)
    {
        foreach (HtmlElement child in root.Children)
        {
            yield return child;
            if (!child.CanHaveChildren)
                continue;
            foreach (var subChild in Descendants(child))
                yield return child;
        }
    }
