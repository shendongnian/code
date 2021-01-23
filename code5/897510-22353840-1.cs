    var xDoc = XDocument.Parse(/* your xml */);
    var reordered = xDoc.Root
                        .Elements("Child")
                        .Select(el => new {
                                            Element = el,
                                            Comments = el.NodesAfterSelf()
                                                         .TakeWhile(n => n.NodeType == XmlNodeType.Comment)
                                          })
                        .OrderBy(pair => (int)pair.Element.Attribute("id"))
                        .SelectMany(pair => new [] { pair.Element }.Concat(pair.Comments));
    xDoc.Root.ReplaceAll(reordered);
