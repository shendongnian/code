    XNamespace gml = "http://www.opengis.net/gml";
    
    var qry = xDoc.Root
             .Elements(gml + "boundedBy")
             .Elements(gml + "Box")
             .Elements(gml + "coord")
             .Select(a=>new
                  {
                      x=a.Element(gml + "X").Value,
                      y=a.Element(gml + "Y").Value
                   });
