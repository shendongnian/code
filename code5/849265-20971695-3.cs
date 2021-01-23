    var doc = XDocument.Load(@"C:\Users\IT-Administrator\Desktop\2014-01-07_Middlesex.xml");
    foreach (var itemsGroup in doc.Element("Incidents").Elements("Incident").GroupBy(x => x.Element("Comment").Value))
    {
        foreach (var item in itemsGroup.Skip(1))
        {
            item.Remove();
        }
    }
    doc.Save(@"C:\Users\IT-Administrator\Desktop\2014-01-07_Middlesex.xml");
