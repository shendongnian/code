    public class rgInventoryItem
    {
        public string id { get; set; }
        public string classid { get; set; }
    }
    public class rgDescription
    {
        public string classid { get; set; }
        public string market_name { get; set; }
    }
    public class CSGOInventory
    {
        public static CSGOInventory FetchInventory(string steamId)
        {
            var url = "http://steamcommunity.com/profiles/" + steamId + "/inventory/json/730/2/";
            return FetchInventoryFromUrl(new Uri(url));
        }
        public static CSGOInventory FetchInventoryFromUrl(Uri url)
        {
            using (WebClient client = new WebClient())
            {
                string response = client.DownloadString(url);
                var inventory = JsonConvert.DeserializeObject<InventoryResponse>(response);
                return new CSGOInventory(inventory);
            }
        }
        readonly InventoryResponse inventory;
        readonly ILookup<string, string> classIdToId;
        readonly ILookup<string, string> marketNameToId;
        CSGOInventory(InventoryResponse inventory)
        {
            if (inventory == null)
                throw new ArgumentNullException();
            this.inventory = inventory;
            this.classIdToId = inventory.rgInventory.ToLookup(pair => pair.Value.classid, pair => pair.Key);
            this.marketNameToId = inventory.rgDescriptions
                .SelectMany(pair => classIdToId[pair.Value.classid].Select(id => new KeyValuePair<string, string>(pair.Value.market_name, id)))
                .ToLookup(pair => pair.Key, pair => pair.Value);
        }
        public IDictionary<string, rgInventoryItem> InventoryItems { get { return this.inventory == null ? null : this.inventory.rgInventory; } }
        public IDictionary<string, rgDescription> InventoryDescriptions { get { return this.inventory == null ? null : this.inventory.rgDescriptions; } }
        public IEnumerable<string> MarketNames { get { return InventoryDescriptions == null ? null : InventoryDescriptions.Values.Select(d => d.market_name); } }
        public IEnumerable<string> InventoryIds { get { return InventoryItems == null ? null : InventoryItems.Keys; } }
        public string getInstanceIdFromMarketName(string name)
        {
            return marketNameToId[name].FirstOrDefault();
        }
        public IEnumerable<string> getInstanceIdsFromMarketName(string name)
        {
            return marketNameToId[name];
        }
        class InventoryResponse
        {
            public Dictionary<string, rgInventoryItem> rgInventory { get; set; }
            public Dictionary<string, rgDescription> rgDescriptions { get; set; }
        }
    }
