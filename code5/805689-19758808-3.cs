        XmlDocument doc = new XmlDocument();
        doc.Load("xml path");
        XmlNode node = doc.SelectSingleNode("/RTT");
        foreach (XmlNode nodes in node.SelectNodes(
            "/AgencyList/Agency Name/RouteList/Route"))
        {
            trainType.Add(r.GetAttribute("Name"));
            XmlNode s = nodes.SelectSingleNode("Route Name/RouteDirectionList/RouteDirection Code/StopList/Stop");
            if (s != null && s["DepartureTimeList"].HasChildNodes)
            {
                // do stuff here
            }
        }
