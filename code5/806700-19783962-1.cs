    public class Hjeke
    {
      public string id { get; set; }
      public string name { get; set; }
      public int percentage { get; set; }
      public string type { get; set; }
    }
    public class Second
    {
      public string id { get; set; }
      public string name { get; set; }
      public int percentage { get; set; }
      public string type { get; set; }
    }
    public class Details
    {
      public Hjeke hjeke { get; set; }
      public Second Second { get; set; }
    }
    public class Students
    {
      public Details details { get; set; }
    }
    public class RootObject
    {
      public int code { get; set; }
      public string message { get; set; }
      public Students students { get; set; }
    }
