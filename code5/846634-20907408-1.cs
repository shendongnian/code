    string url = "http://maps.googleapis.com/maps/api/geocode/" + "xml?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&sensor=false";
    WebResponse response = null;
    bool is_geocoded = true;
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    request.Method = "GET";
    response = request.GetResponse();
    string lat = "";
    string lng = "";
    string loc_type = "";
    if (response != null)
    {
        XPathDocument document = new XPathDocument(response.GetResponseStream());
        XPathNavigator navigator = document.CreateNavigator();
        // get response status
        XPathNodeIterator statusIterator = navigator.Select("/GeocodeResponse/status");
        while (statusIterator.MoveNext())
        {
            if (statusIterator.Current.Value != "OK")
            {
                is_geocoded = false;
            }
        }
        // get results
        if (is_geocoded)
        {
            XPathNodeIterator resultIterator = navigator.Select("/GeocodeResponse/result");
            while (resultIterator.MoveNext())
            {
                XPathNodeIterator geometryIterator = resultIterator.Current.Select("geometry");
                while (geometryIterator.MoveNext())
                {
                    XPathNodeIterator locationIterator = geometryIterator.Current.Select("location");
                    while (locationIterator.MoveNext())
                    {
                        XPathNodeIterator latIterator = locationIterator.Current.Select("lat");
                        while (latIterator.MoveNext())
                        {
                            lat = latIterator.Current.Value;
                        }
                        XPathNodeIterator lngIterator = locationIterator.Current.Select("lng");
                        while (lngIterator.MoveNext())
                        {
                            lng = lngIterator.Current.Value;
                        }
                        XPathNodeIterator locationTypeIterator = geometryIterator.Current.Select("location_type");
                        while (locationTypeIterator.MoveNext())
                        {
                            loc_type = locationTypeIterator.Current.Value;
                        }
                    }
                }
            }
        }
    }
