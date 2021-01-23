    private void AddTempRoot(XDocument doc)
    {
        XElement tempRoot= new XElement("MyTempRood");
        var elements = doc.Elements();
        foreach (var element in elements)
        {
            element.Remove();
            tempRoot.Add(element);
        }
        doc.Add(tempRoot);
    }
    private void RemoveTempRoot(XDocument doc)
    {
        var tempRoot = doc.Root;
        tempRoot.Remove();
        var elements = tempRoot.Elements();
        foreach (var element in elements)
        {
            element.Remove();
            doc.Add(element);
        }
    }
