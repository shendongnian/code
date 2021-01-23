    public class PaypalApiError
    {
      public string name { get; set; }
      public string message { get; set; }
      public List<Dictionary<string, string>> details { get; set; }
      public string debug_id { get; set; }
      public string information_link { get; set; }
    }
