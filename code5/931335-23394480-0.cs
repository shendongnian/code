    JObject jo = JObject.Parse(json);
    List<Game> games = new List<Game>();
    foreach (JProperty prop in jo.Properties())
    {
        if (prop.Value.Type == JTokenType.Array)
        {
            games.Add(new Game
            {
                ID = Convert.ToInt32(prop.Name),
                Name = (string)prop.Value[0],
                Amount = (int)prop.Value[1]
            });
        }
    }
