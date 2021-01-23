    // stringifiedJson is {"Name":"George","Age":25}
    {
        dynamic deserializedDynamic = JsonConvert.DeserializeObject(stringifiedJson);
        string name = deserializedDynamic.Name;
        int age = deserializedDynamic.Age;
    }
    {
        var deserializedAnon = JsonConvert.DeserializeAnonymousType(stringifiedJson,
                                 new { Name = default(string), Age = default(int) });
        string name = deserializedAnon.Name;
        int age = deserializedAnon.Age;
    }
    {
        var deserializedDict =
      JsonConvert.DeserializeObject<Dictionary<string, object>>(stringifiedJson);
        string name = (string)deserializedDict["Name"];
        // Age is a long, two casts required
        int age = (int)(long)deserializedDict["Age"];
    }
    {
        var deserializedDictDyn =
      JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(stringifiedJson);
        string name = deserializedDictDyn["Name"];
        // Age is a long, one cast required with dynamic
        int age = (int)deserializedDictDyn["Age"];
    }
    {
        var deserializedJObject = JObject.Parse(stringifiedJson);
        string name = (string)deserializedJObject.GetValue("Name");
        int age = (int)deserializedJObject.GetValue("Age");
    }
