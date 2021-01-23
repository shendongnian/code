    public class Item {
        public string Name { get; set; }
        public string Address { get; set; }
    }
    Dictionary<string, Item> itemList = 
        JsonConvert.DeserializeObject<Dictionary<string, Item>>( myJsonString );
