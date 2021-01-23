    public static class DictionaryExtensions
    {
        public static Item GetItem(this Dictionary<string, string> dictionary)
        {
            var type = dictionary.GetTypeOfItem().ToLowerInvariant();
            var json = dictionary.ToJson();
            switch (type)
            {
                case "sword":
                    return GetItem<Weapon>(json);
                case "armor":
                    return GetItem<Armor>(json);
                default:
                    throw new ArgumentOutOfRangeException("dictionary", type, string.Format("Unknown type: {0}", type));
            }
        }
        private static string GetTypeOfItem(this Dictionary<string, string> dictionary)
        {
            if(!dictionary.ContainsKey("Type"))
                throw new ArgumentException("Not valid type!");
            return dictionary["Type"];
        }
        private static string ToJson(this Dictionary<string, string> dictionary)
        {
            var output = new StringBuilder("{");
            foreach (var property in dictionary.OrderBy(k => k.Key))
                output.AppendFormat("\"{0}\":\"{1}\",", property.Key, property.Value);
            output.Append("}");
            return output.ToString();
        }
        private static Item GetItem<TItem>(string json) where TItem: Item
        {
            return JsonConvert.DeserializeObject<TItem>(json);
        }
    }
