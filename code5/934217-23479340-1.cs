    [Fact]
    public void Test()
    {
        XElement root = XElement.Load("data.xml");
        var years = string.Join(",", root.Descendants("years").Select(x => x.Attribute("year").Value));
        root.Add(new XElement("test", new XElement("years", years)));
        root.Save("data.xml");
    }
