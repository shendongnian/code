    string json = @"{
      ""id"": 123,
      ""attr"": {
        ""info"": {
          ""dat"": [{""data"":1}, {""data"":2}]
        }
      }
    }";
    JObject jo = JObject.Parse(json);
    DataContainer container = new DataContainer();
    container.ID = jo["id"].Value<int>();
    container.Data = jo["attr"]["info"]["dat"].ToObject<List<Dat>>();
    Console.WriteLine("id:" + container.ID);
    foreach (Dat d in container.Data)
    {
        Console.WriteLine(d.Data);
    }
