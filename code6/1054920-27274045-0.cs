    XDocument doc = XDocument.Load("base.xsd");
    var element = doc.Descendants()
                     .FirstOrDefault(e => e.Attributes()
                     .Any(a => a.Name=="name" && a.Value == "StringNotNull")) as XElement;
    var minLength = element.Descendants()
                           .FirstOrDefault(e => e.Name.LocalName == "minLength")
                           .Attribute("value").Value;
    var maxLength = element.Descendants()
                           .FirstOrDefault(e => e.Name.LocalName == "maxLength")
                           .Attribute("value").Value;
