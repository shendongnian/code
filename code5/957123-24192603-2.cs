    XDocument doc = XDocument.Parse(xml);
    foreach (XElement subroot in doc.Descendants("newsubroot"))
    {
        // get subroot elements
        foreach (var subsubroot in subroot.Descendants("element"))
        {
            // get subsubroot elements
        }
    }
