    List<string> values = new List<string>();
    using (StringReader sr = new StringReader(stringXML))
    using (XmlReader xr = XmlReader.Create(sr))
    {
        while (xr.Read())
        {
            if (xr.NodeType == XmlNodeType.Element && xr.Name == "item" && xr.GetAttribute("address") == "123" )
            {
                values.Add(xr.GetAttribute("address"));     
            }
        }
    }
