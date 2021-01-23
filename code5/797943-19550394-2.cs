        XNamespace ns = XNamespace.Get("http://www.w3.org/2005/Atom");
        XNamespace nsCap = XNamespace.Get("urn:oasis:names:tc:emergency:cap:1.1");
        var xlist = root.Descendants(ns + "entry").Select(elem => new
                {
                    Title = elem.Descendants(ns + "title").FirstOrDefault(),
                    AreaDesc = elem.Descendants(nsCap + "areaDesc").FirstOrDefault()
                });
        foreach (var el in xlist)
        {
            Console.WriteLine(string.Format("title: {0}, AreaDesc: {1}",
                el.Title != null ? el.Title.Value : string.Empty,
                el.AreaDesc != null ? el.AreaDesc.Value : string.Empty));
        }
