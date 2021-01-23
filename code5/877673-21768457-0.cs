    var xlist = doc.Descendants(ns + "entry").Select(elem => new
    {
        Title = elem.Descendants(ns + "title").FirstOrDefault(),
        AreaDesc = elem.Descendants(nsCap + "areaDesc").FirstOrDefault(),
        GeocodeElements = elem.Descendants(nsCap + "geocode").Descendants()
    });
    foreach (var el in xlist)
    {
        System.Diagnostics.Debug.WriteLine(string.Format("title: {0}, AreaDesc: {1}",
            el.Title != null ? el.Title.Value : string.Empty,
            el.AreaDesc != null ? el.AreaDesc.Value : string.Empty));
        var geoCodeValues = el.GeocodeElements
                    .Where(o => o.Name == ns + "value").ToList();
        var geoCodeValueNames = el.GeocodeElements
                    .Where(o => o.Name == ns + "valueName").ToList();
        var pairs = geoCodeValueNames.Zip(geoCodeValues, (vn, v) =>
                            new Tuple<String, String>(vn.Value, v.Value)).ToList();
    }
