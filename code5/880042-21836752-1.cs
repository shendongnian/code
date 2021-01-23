    var element = new XElement...;
    var stringBuilder = new StringBuilder();
    using (var stringWriter = new StringWriter(stringBuilder))
    {
        element.Save(stringWriter);
    }
    stringBuilder.Replace(" />", "/>");
    var xml = stringBuilder.ToString();
    Console.WriteLine(xml);
