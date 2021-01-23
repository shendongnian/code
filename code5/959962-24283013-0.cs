    XNamespace ns = "http://http://lilleker-it.co.uk/";
    var query = doc.Descendants(ns + "license").Select(s => new
                    {
                        EMAIL = s.Element(ns + "Email").Value,
                        SID = s.Element(ns + "SID").Value
                    }).ToList();
    string e = query[0].EMAIL;
    string id = query[0].SID;
