    public class RootObject
    {
      public Detail details { get; set; }
    }
    public class Detail
    {
      [JsonProperty(PropertyName="MUMBAI")]
      public City Mumbai { get; set; }
      [JsonProperty(PropertyName = "DELHI")]
      public City Delhi { get; set; }
      // Add more of the above property definitions for each individual city that might be inside the returned JSON,
      // which is a very bad design. (Example city of Rohtak)
      [JsonProperty(PropertyName = "ROHTAK")]
      public City Rohtak { get; set; }
    }
    public class City
    {
      public List<Car> car { get; set; }
    }
    public class Car
    {
      public string id { get; set; }
      public string text { get; set; }
      public string sub_text { get; set; }
      public string category_id { get; set; }
      // Might need to add additional possible properties here
    }
