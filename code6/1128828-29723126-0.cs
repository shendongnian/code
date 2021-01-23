    private static standings WebDeserialize()
    {
      standings s = null;
      var srlz = new XmlSerializer(typeof(standings));
      //
      var uri = "http://developer.sportsdatallc.com/files/soccer_v2_standings.xml";
      var xmlReader = XmlReader.Create (uri);
      s = (standings)srlz.Deserialize(xmlReader);
      return s;
    }
    static async Task AsyncWebDeserialize()
    {
      Task<standings> task = Task.Run<standings>(() => WebDeserialize());
      standings s = await task;
      Console.WriteLine("Cat:{0} Gen:{1}", s.categories.Length, s.generated);
    }
