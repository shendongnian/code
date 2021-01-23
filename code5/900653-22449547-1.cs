    if (train != null)
    {
        int entryId = (int)train.Element("entry").Attribute("id");
        var stations = train.Element("stations")
                            .Elements("station")
                            .Select(s => new {
                                Name = (string)s.Attribute("name"),
                                Id = (string)s.Attribute("id"),
                                Arrival = (string)s.Attribute("arr"),
                                Departure = (string)s.Attribute("dep")
                            }).ToList();
    }
