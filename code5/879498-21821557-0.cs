    XElement doc=XElement.Load(url);
    var elements=doc.Elements()
                    .Where(x=>
                             x.Attributes("id").Value=="AUDEUR" &&
                             (double)x.Element("Rate")>=0.6602 &&
                             DateTime.Compare((DateTime)x.Element("Date"),DateTime.Parse("2/17/2014"))>=0
                          )
                    .Select(e=>
                                new
                               {
                                    Name=e.Element("Name").Value,
                                    Rate=e.Element("Rate").Value....
                               }
                           );
