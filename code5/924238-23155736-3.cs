    public async Task<string> GetTestAsync(int id)
    {
      var client = new HttpClient();
      var result = await client.GetStringAsync("http://thegamesdb.net/api/GetArt.php?id=" + id);
      var feedXml = XDocument.Parse(result);
      var gameData = feedXml.Root.Descendants("Images").Select(x => new GetArt
      {
        BoxArtFrontThumb = new Uri(GetBoxArtFront(x)),
      }).ToList();
      foreach (var item in gameData) GetArtItems.Add(item);
      return "http://thegamesdb.net/banners/" + gameData.Single().BoxArtFrontThumb.ToString()
    }
