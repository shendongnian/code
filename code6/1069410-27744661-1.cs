        XElement data = XElement.Load(@"Files\Data.xml");
        var dataCollections = data.Elements();
        XElement newData = new XElement("catalog");
        foreach (var item in dataCollections)
        {
            var price = item.Element("price");
            if (price.Value != "")
            {
                newData.Add(item);
            }
        }
        newData.Save(@"Files\Data.xml");
