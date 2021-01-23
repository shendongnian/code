    public static void FindAndReplace(this XDocument doc, string key, string newValue)
    {
        var elem = doc.Descendants("add")
                      .FirstOrDefault(d => d.Attribute("key").Value == key);
        if (elem != null)
            elem.Attribute("value").Value = newValue;
    }
