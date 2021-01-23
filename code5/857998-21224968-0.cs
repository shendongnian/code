    var result = xmlDoc.Root.Elements(atom + "entry")
        .Select(e => new {
            Title = e.Element(atom + "title").Value,
            Id = e.Element(atom + "id").Value,
            Urls = e.Elements(atom + "link")
                .Where(l => l.Element(metadata + "inline") != null)
                .SelectMany(l => l.Element(metadata + "inline")
                    .Element(atom + "feed")
                    .Elements(atom + "entry")
                    .Select(e1 => e1.Element(atom + "content")
                        .Element(metadata + "properties")
                        .Element(dataservices + "Url").Value))
            });
    
    foreach(var r in result)
    {
    	Debug.WriteLine("{0},{1},{2}", r.Title, r.Id, String.Join(",", r.Urls));
    }
