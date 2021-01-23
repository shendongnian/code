    var xDoc = XDocument.Load("path");
    var items = xDoc.Root.Descendants("item")
                .SelectMany(x => x.Descendants()
                    .Select(a => new Item
            {
                field = a.Name.ToString(),
                value = (string) a);
            }));
