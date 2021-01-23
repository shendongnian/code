    foreach (XmlNode node in nodes)
    {
        string titl = node["title"].InnerText;
        string ide = node["id"].InnerText;
        string cty;
        var ctyNode = node.SelectSingleNode("link/m:inline/de:feed/de:id");
        if (ctyNode != null)
        {
            cty = ctyNode.InnerText
        }
        Debug.WriteLine("Data :" + titl+"ID :"+ide);
    }
