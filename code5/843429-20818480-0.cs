    var items = XDocument.Load(fname)
         .Descendants("SHOPITEM")
         .Select(s => new Item
         {
             Name = (string)s.Element("PRODUCTNAME"),
             Images = s.Elements("IMGURL_ALTERNATIVE").Select(x => (string)x).ToList()
         });
