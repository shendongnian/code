    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var jsonObject = JObject.ReadFrom(reader);
        var type = jsonObject.Value<string>("type");
        if (type == "bike")
        {
            return jsonObject.ToObject<Bike>();
        }
        else if (type == "car")
        {
            return jsonObject.ToObject<Car>();
        }
        throw new JsonSerializationException();
    }
