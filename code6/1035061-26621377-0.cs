    private void UpdateOrCreateAppSetting(string filename, string site, 
                                          string key, string value)
    {
        string path = "\"@" + filename + "\""; 
        XDocument doc = XDocument.Load(path);
        XPathString xpath = new XPathString("//Site[Id={0}]/add[@key={1}]", site, key);
        XElement node = doc.Root.XPathElement(xpath, true); // true = create if not found
        node.Set("value", value, true); // set as attribute, creates attribute if not found
        doc.Save(filename);
    }
