    const string path = "c:\\CoordinatesWessel.xml";
    const string path2 = "c:\\CoordinatesWessel2.xml";
    punten puntenVariable;
    if (File.Exists(path) && File.ReadAllText(path).Deserialize(out puntenVariable))
    {
        foreach (var item in puntenVariable.Placemark)
        {
            item.coordinates = string.Join(",",item.coordinates.Split(',').Reverse());
        }
        var ser = new XmlSerializer(typeof(punten));
        using (var writer = XmlWriter.Create(path2))
        {
            ser.Serialize(writer, puntenVariable);
        }
    }
