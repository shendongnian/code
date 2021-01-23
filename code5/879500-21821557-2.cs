    XElement doc=XElement.Load(url);
    var elements=doc.Elements()
                    .Where(x=>
                             x.Attribute("id").Value=="AUDEUR" &&
                             (double)x.Element("Rate")>=0.6602 &&
                             DateTime.Compare((DateTime)x.Element("Date"),DateTime.Parse("2/17/2014"))>=0
                          )
                    .Select(e=>
                                new
                               {
                                    Id=e.Attribute("id").Value,
                                    Name=e.Element("Name").Value,
                                    Rate=e.Element("Rate").Value....
                               }
                           );
