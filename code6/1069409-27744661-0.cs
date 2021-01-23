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
