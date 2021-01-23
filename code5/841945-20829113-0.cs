    var strJSON = "{\"id\":34379899,\"name\":\"Revelation22\",\"profileIconId\":547,\"summonerLevel\":30,\"revisionDate\":1387913628000}";
    var dict = new JavaScriptSerializer()
               .Deserialize<Dictionary<string, object>>(strJSON);
    Console.WriteLine(dict["name"]);
    Console.WriteLine(ToDateTime((long)dict["revisionDate"]));
---
    DateTime ToDateTime(long l)
    {
        return  new DateTime(1970, 1, 1).AddMilliseconds(l);
    }
