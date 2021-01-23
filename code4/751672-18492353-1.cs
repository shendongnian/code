    public class Item
    {
      public string item_id { get; set; }
      public string name { get; set; }
      public string description { get; set; }
      public string type { get; set; }
      ...
      // List all common properties here
      public Item() { } 
      // It's important to have the public default constructor implemented 
      // if you intend on overloading it for your own purpose later
    }
