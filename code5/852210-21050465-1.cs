    using (var sr = new StreamReader(stream))
    {
        using (var jr = new JsonTextReader(sr))
        {
            var root = serializer.Deserialize<JObject>(jr);
            // Deserialize other elements
            var time = root.GetValue("time");
            var parsedTime = time.ToObject<LocalDateTime>(serializer);
        }
    }
