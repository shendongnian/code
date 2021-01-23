    punten puntenVariable;
    if (xmlString.Deserialize(out puntenVariable))
    {
        //do something, ex: swap coordinates
        foreach (var item in puntenVariable.Placemark)
        {
            item.coordinates = string.Join(",",item.coordinates.Split(',').Reverse());
        }
    }
