    XmlReader r = XmlReader.Create(new StringReader(xml));
    IList<string> res = new List<string>();
    while (r.Read()) {
        if (r.IsStartElement("D")) {
            res.Add(r.GetAttribute("cc"));
        }
    }
