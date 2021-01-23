    List<Markers> markers = new List<Markers>();
    foreach (XmlNode childNode in n)
    {
        if(childNode.Name == "GEOData")
        {
            markers.Add(new Markers
                {
                    City = childNode.Attributes["City"].Value,
                    Longitude= childNode.Attributes["Longitude"].Value,
                    Latitude= childNode.Attributes["Latitude"].Value
                });
        }
    }
    rptMarkers.DataSource = markers;
    rptMarkers.DataBind();
