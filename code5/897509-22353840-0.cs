    var xDoc = XDocument.Parse(/* your xml */);
    var reordered = xDoc.Root
                        .Elements("Child")
                        .Select(el => new { Element = el, Comment = el.NextNode })
                        .OrderBy(pair => (int)pair.Element.Attribute("id"))
                        .SelectMany(pair => new [] { pair.Element, pair.Comment });
    xDoc.Root.ReplaceAll(reordered);
