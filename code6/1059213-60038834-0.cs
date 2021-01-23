string json = JsonConvert.SerializeObject(
  class, 
  Newtonsoft.Json.Formatting.Indented, 
  new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }
);
as below,
string json = JsonConvert.SerializeObject(
  class, 
  Newtonsoft.Json.Formatting.Indented, 
  new JsonSerializerSettings { 
    NullValueHandling = NullValueHandling.Ignore,
    DefaultValueHandling = DefaultValueHandling.Ignore 
  }
);
