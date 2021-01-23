    var feedXml = XDocument.Parse(e.Result);
    var gameDataTasks = feedXml.Root.Descendants("Game").Select(
        async x => new GetGamesList
        {
          ID = (int)x.Element("id"),
          GameTitle = (string)x.Element("GameTitle"),
          ReleaseDate = (string)x.Element("ReleaseDate"),
          Platform = (string)x.Element("Platform"),
          Front = new Uri(await GetTestAsync((int)x.Element("id"))),
        }).ToList();
    var gameData = await Task.WhenAll(gameDataTasks);
    foreach (var item in gameData)
    {
      GetGamesListItems.Add(item);
    }
