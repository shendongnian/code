    var links = oLinksConfig
        .Descendants("Links")
        .Select(
            linkElement =>
            {
                var link = new HyperLink { /* your initializations of properties with setters */ };
                //statements are after you have an instance of the class
                link.ContentStart.InsertTextInRun(linkElement.Element("Text").Value;
                return link;
             })
         .ToList();
