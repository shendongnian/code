    var feedXml = XDocument.Parse(e.Result);
    
    List<GetGamesList> gameData = new List<GetGamesList>();
    foreach (var item  in feedXml.Root.Descendants("Game"))
    {
        var gl = new GetGamesList();
        gl.ID = (int)x.Element("id");
        gl.GameTitle = (string)x.Element("GameTitle");
        gl.ReleaseDate = (string)x.Element("ReleaseDate");
        gl.Platform = (string)x.Element("Platform");
        gl.Front = new Uri(await GetTest((int)x.Element("id")));//Note the await keyword
    
        gameData.Add(gl);
    }
    foreach (var item in gameData)
    {
        GetGamesListItems.Add(item);
    }
