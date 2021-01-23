    var xmlFile = XDocument.Load(someFile);
    var query = from item in xmlFile.Descendants("childobject")
                where !String.IsNullOrEmpty(item.Attribute("using")
                select new 
                {
                    AttributeValue = item.Attribute("using").Value
                };
