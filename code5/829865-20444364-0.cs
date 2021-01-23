    var obj = new JavaScriptSerializer()
                  .Deserialize<Dictionary<string,ItemCollection>>(json);
---
    public class ItemCollection
    {
        public string Name { get; set; }
        public string  MaxVlaue { get; set; }
        public string MinValue { get; set; }
        public Dictionary<string, Item> Items  { get; set; }
    }
    public class Item
    {
        public string ItemName { get; set; }
        public bool IsEditable { get; set; }
        public bool IsClicked { get; set; }
        public bool IsSelected { get; set; }
    }
