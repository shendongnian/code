    internal class ParsedJson
    {
      public uint                Timestamp { get; set; }
      public List<List<decimal>> Bids      { get; set; }
      public List<List<decimal>> Asks      { get; set; }
      public static ParsedJson CreateInstance( string json )
      {
        ParsedJson instance = Newtonsoft.Json.JsonConvert.DeserializeObject<ParsedJson>( json );
        return instance;
      }
    }
