    var response = client.ndfdGen(latlong);
    XDocument xd = null;
    using (XmlReader xr = XmlReader.Create(new StringReader(response))) // load the response into an XmlReader
    {
        xr.MoveToContent(); // go to the content node
        using (XmlReader xr = XmlReader.Create(new StringReader(response))) // load the response into an XmlReader
        {
            xr.MoveToContent(); // go to the content node
            xr.ReadToDescendant("dwmlOut"); // go to the dwmlOut node
            xr.Read(); // move to the CDATA in that node
            xd = XDocument.Parse(xr.Value);
        }
    }
    string startTime = xd.Descendants("start-valid-time").First().Value;
