    [JsonProperty("_items")]
    private ItemsContainer _items;
    [JsonObject(MemberSerialization.OptIn)]
    class ItemsContainer
    {
        [JsonExtensionData]
        private IDictionary<string, JToken> _items;
        public IEnumerable<Item> Items
        {
            get
            {
                return _items.Values.Select(i => i.ToObject<Item>());
            }
        }
    }
