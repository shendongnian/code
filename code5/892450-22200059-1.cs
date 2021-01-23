    public Dictionary<int, AppData> LoadData(string xmlPath)
    {
        return XDocument.Load(xmlPath)
            .Descendants("app")
            .Select(e => new AppData
            {
                Id = Convert.ToInt32(e.Attribute("num").Value),
                Name = e.Descendants("appname").Single().Value
            })
            .ToDictionary(x => x.Id);
    }
