    JsonSerializerSettings settings = new JsonSerializerSettings();
    settings.Converters.Add(new ObjectConverter());
    var deserializedContainer = JsonConvert.DeserializeObject<Container>(json, settings);
    var type = ((JObject)deserializedContainer.Test)["$type"];
    // Type is Snarfblat
