    try
    {
        //create a request to geoiptool.com
        var request = WebRequest.Create(new Uri("http://geoiptool.com/data.php")) as HttpWebRequest;
    if (request != null)
    {
        //set the request user agent
        request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; SLCC1; .NET CLR 2.0.50727)";
        //get the response
        using (var webResponse = (request.GetResponse() as HttpWebResponse))
            if (webResponse != null)
                using (var reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    //get the XML document
                    var doc = new XmlDocument();
                    doc.Load(reader);
                    //now we parse the XML document
                    var nodes = doc.GetElementsByTagName("marker");
                    Guard.AssertCondition(nodes.Count > 0,"nodes",new object());
                    //make sure we have nodes before looping
                    //if (nodes.Count > 0)
                    //{
                        //grab the first response
                        var marker = nodes[0] as XmlElement;
                        Guard.AssertNotNull(marker, "marker");
                        
                        var _geoLoc = new GeoLoc();
                        //get the data and return it
                        _geoLoc.City = marker.GetAttribute("city");
                        _geoLoc.Country = marker.GetAttribute("country");
                        _geoLoc.Code = marker.GetAttribute("code");
                        _geoLoc.Host = marker.GetAttribute("host");
                        _geoLoc.Ip = marker.GetAttribute("ip");
                        _geoLoc.Latitude = marker.GetAttribute("lat");
                        _geoLoc.Lognitude = marker.GetAttribute("lng");
                        _geoLoc.State = GetMyState(_geoLoc.Latitude, _geoLoc.Lognitude);
                        return _geoLoc;
                    //}
                }
    }
       // this code would only be reached if something went wrong 
      // no "marker" node perhaps?
       return new GeoLoc();
     }
     catch (Exception ex)
     {
         throw;
     }
    }
