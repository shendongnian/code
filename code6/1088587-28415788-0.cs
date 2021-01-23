    static public class XmlDictionarySerializer<A, B>
    {
        public class Item
        {
            public A Key { get; set; }
            public B Value { get; set; }
        }
        static public void Serialize(IDictionary<A, B> dictionary, string filePath)
        {
            List<Item> itemList = new List<Item>();
            foreach (A key in dictionary.Keys)
            {
                itemList.Add(new Item() { Key = key, Value = dictionary[key] });
            }
            XmlDataSerializer.Serialize<List<Item>>(itemList, filePath);
        }
        static public Dictionary<A, B> DeserializeDictionary(string filePath)
        {
            Dictionary<A, B> dictionary = new Dictionary<A, B>();
            List<Item> itemList = XmlDataSerializer.Deserialize<List<Item>>(filePath);
            foreach (Item item in itemList)
            {
                dictionary.Add(item.Key, item.Value);
            }
            return dictionary;
        }
    }
