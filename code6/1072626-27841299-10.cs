    // Just a helper.
    private static Tuple<XElement, XElement> Compare(
        string xml1, 
        string xml2, 
        bool compareAttributeValues)
    {
        return Compare(
            XElement.Parse(xml1), 
            XElement.Parse(xml2), 
            compareAttributeValues);
    }
    
    // Compares XElements recursively
    // and returns the two nodes that are different if any.
    private static Tuple<XElement, XElement> Compare(
        XElement xElm1,
        XElement xElm2, 
        bool compareAttributeValues)
    {
        // Elements are different if they have a different number of children.
        if (xElm1.Elements().Count() != xElm2.Elements().Count())
        {
            return new Tuple<XElement, XElement>(xElm1, xElm2);
        }
    
        // Enumerate both elements at the same time.
        var elements = Enumerable.Zip(
            xElm1.Elements(), 
            xElm2.Elements(), 
            (x, y) => new Tuple<XElement, XElement>(x, y));
        foreach (var item elements )
        {
            // Elements are equal if they have the same names...
            bool haveSameNames = xElm1.Name.LocalName == xElm2.Name.LocalName;
            // and the same attributes.
            bool haveSameAttributes =
                item.Item1
                // Concatenate and group attributes by their name.
                .Attributes()
                .Concat(item.Item2.Attributes())
                .GroupBy(x => x.Name.LocalName, (key, items) => new
                {
                    Name = key,
                    Items = items,
                    // Attiribute value comparison can be skipped.
                    // If enabled compare attribute values.
                    // They are equal if the result is only one group.
                    HaveSameValues = 
                        compareAttributeValues == false 
                        || items.GroupBy(y => y.Value).Count() == 1,
                    Count = items.Count()
                })
                // Each attribute group must contain two items
                // if they are identical (one per element).
                .Where(x => x.Count != 2 || x.HaveSameValues == false)
                .Any() == false;
            if (!haveSameNames || !haveSameAttributes)
            {
                return item;
            }
            else
            {
                // Return the different nodes.
                return Compare(item.Item1, item.Item2, compareAttributeValues);
            }
        }
        // No differences found.
        return null;
    }
