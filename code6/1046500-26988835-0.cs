    List<HomeOutput> homeOutputList = localDictionary.SelectMany(x => x.Value.Select(y => new HomeOutput()
    {
        CityId = x.Key,
        Id = y.Id,
        Address = y.Address,
        Color = y.Color
    })).ToList();
