    public GeocodeResponse
    {
      public string Status { get; set; }
      public Result Result { get; set; }
      public class Result
      {
        public string type { get; set; }
        public string formatted_address { get; set; }
        // etc..
      }
    }
