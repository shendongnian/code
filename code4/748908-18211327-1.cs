    public List<String> getElementValues(string path,string elementName)
    {
        XElement doc= XElement.Load(path);
        var elementList=doc.Descendants().Elements();
        return elementList.Where(x=>x.Name.LocalName==elementName)
                          .Select(y=>y.Value)
                          .ToList();
    }
