    [JsonProperty("event")]
    public string Event { get; set; }
    public string @event { get; set; }
    public string Event { get; set; }
    var s = JsonConvert.SerializeObject(myObj, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
