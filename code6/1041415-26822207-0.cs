    var collection = new LocationCollection();
    collection.Add(new Location(47.5, 2.75));
    collection.Add(new Location(48.5, 2.75));
    collection.Add(new Location(43.5, 5.75));
    map.SetView(new LocationRect(collection));
