    class Example
    {
      [JsonConverter(typeof(StringEnumConverter))]
      public ActionType ActionType { get; set; }
    }
    var serializedObject = JsonConvert.SerializeObject(new Example(), Formatting.Indented);
