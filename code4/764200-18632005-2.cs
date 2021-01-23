    SomeRootElement root;
    using (var sr = new StringReader(xmlStr))
    using (var xr = XmlReader.Create(sr))
    {
        var ser = new XmlSerializer(typeof(SomeRootElement));
        root = (SomeRootElement)ser.Deserialize(xr);
    }
    var items = from item in root.Items
                where item.DataType == DataType.StaticData
                select item;
    foreach (var item in items)
    {
        Console.WriteLine("{0}, {1}", item.Find, item.StaticValue);
    }
