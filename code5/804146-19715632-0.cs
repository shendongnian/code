    var xmlResults = from element in Root.Elements().Elements()
                     select new Credentials
                     {
                         Username = element.Element("Username").Value,
                         Password = element.Element("Password").Value
                     };
    return xmlResults.ToList();
