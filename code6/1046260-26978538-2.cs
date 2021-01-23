            public class Item
            {
                public string key { get; set; }
                public string name { get; set; }
                public Item child { get; set; }
                public Item(string ItemKey, string ItemName)
                {
                    this.key = ItemKey;
                    this.name = ItemName;
                }
            }
            public static void Test()
            {
                List<Item> data = new List<Item>();
                Item key1 = new Item("1", "folder 1");
                data.Add(key1);
                Item key5 = new Item("5", "(1) nested file");
                key1.child = key5;
                Item key12 = new Item("12", "(1) nested file");
                key5.child = key12;
                Item key2 = new Item("2", "folder 2");
                data.Add(key2);
                Item key6 = new Item("6", "(1) nested file");
                key2.child = key6;
                string serialized = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                List<Item> deserialized = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Item>>(serialized);
            }
