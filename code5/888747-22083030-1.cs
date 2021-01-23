    XNamespace ns = "http://webservices.whitespacews.com/";
    XDocument doc;
    using (var stream = response.GetResponseStream())
    {
        doc = XDocument.Load(stream);
    }
    var query = xmlDoc.Descendants(ns + "Collection")
                      .Select(x => new
                      {
                          Day = x.Element(ns + "Day").Value,
                          Date = x.Element(ns + "Date").Value
                      });
