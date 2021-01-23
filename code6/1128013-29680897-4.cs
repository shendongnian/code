    //Retrieves markers from somewhere and converts them to a JSON string
    public string GetMarkersJson()
    {
        List<Marker> markers = GetData("string");
        return JsonConvert.SerializeObject(markers); //using JSON.NET for serialization
    }
    //Parses an XML string and retrieves a list of Marker objects. Should probably go in a utility class somewhere, not in code behind
    List<Marker> GetData(string strRsult)
    {
        List<Marker> markers = new List<Marker>();
        XmlDataDocument xmlDataDoc = new XmlDataDocument();
        xmlDataDoc.LoadXml(strRsult);
        foreach (XmlNode n in xmlDataDoc.DocumentElement.GetElementsByTagName("Property"))
        {
            if (n.HasChildNodes)
            {
                foreach (XmlNode childNode in n)
                    {
                        if (childNode.Name=="GEOData")
                        {
                            markers.Add(new Marker
                            {
                                City = childNode.Attributes["City"].Value,
                                Longitude = childNode.Attributes["Longitude"].Value,
                                Latitude = childNode.Attributes["Latitude"].Value
                            });
                        }
                    }
                }
        return markers;
    }
