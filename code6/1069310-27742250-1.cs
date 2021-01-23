    result = xmlResponse.Descendants(ns + "Hostip").Select(Function(x) New LocationInfo() With {
                 .CountryCode = x.Element(ns + "countryAbbrev").Value,
                 .CountryName = x.Element(ns + "countryName").Value,
                 .Latitude = Single.Parse(x.Descendants(gml + "coordinates").[Single]().Value.Split(","c)(0)),
                 .Longitude = Single.Parse(x.Descendants(gml + "coordinates").[Single]().Value.Split(","c)(1)),
                 .CityName = Split(x.Element(gml + "name").Value, ",")(0),
                 .State = Trim(Split(x.Element(gml + "name").Value, ",")(1))
                    }).SingleOrDefault()
    result = xmlResponse.Descendants(ns + "Hostip").Select(x => new LocationInfo{
                 CountryCode = x.Element(ns + "countryAbbrev").Value,
                 CountryName = x.Element(ns + "countryName").Value,
                 Latitude = Single.Parse(x.Descendants(gml + "coordinates").[Single]().Value.Split(","c)(0)),
                 Longitude = Single.Parse(x.Descendants(gml + "coordinates").[Single]().Value.Split(","c)(1)),
                 CityName = Split(x.Element(gml + "name").Value, ",")(0),
                 State = Trim(Split(x.Element(gml + "name").Value, ",")(1))
                    }).SingleOrDefault();
