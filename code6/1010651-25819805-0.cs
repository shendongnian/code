    var buttons = doc.GetElementsByTagName("button");
    foreach (var button in buttons )
    {
        Console.WriteLine(((XmlElement) button).GetAttribute("Id"));
        Console.WriteLine(((XmlElement) button ).InnerText);
    }
    var rect= doc.GetElementsByTagName("rect ");
    foreach (var button in buttons )
    {
        Console.WriteLine(((XmlElement) button).GetAttribute("ID"));
        Console.WriteLine(((XmlElement) button).InnerText);
        Console.WriteLine(((XmlElement)rect).ParentNode);
    }
