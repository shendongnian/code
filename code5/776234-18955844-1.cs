    var list = new List<Base>();
    list.Add(new Base { a = 5 });
    list.Add(new Inh { a = 10, b = 5 });
    var ser = new XmlSerializer(list.GetType());
    var sb = new StringBuilder();
    using (var xw = XmlWriter.Create(sb))
    {
        ser.Serialize(xw, list);
    }
    string xml = sb.ToString();
    Console.WriteLine(xml);
    using (var xr = XmlReader.Create(new StringReader(xml)))
    {
        var clone = (List<Base>)ser.Deserialize(xr);
    }
